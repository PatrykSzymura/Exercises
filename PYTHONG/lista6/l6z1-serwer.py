from tkinter import *
import tkinter as tk
import mysql.connector as msqlc


#<== Dictionary with Data to connect with database ==>
connection_Data = {
    'database_Name': "students.db",
    'host': "localhost",
    'user': "tester",
    'psswd' : "cOKOLWIEK@123",
    'database': "students"
}

#<== Main program class ==>
class App:

    #<== Initialization of object with main code ==>
    def __init__(self,database = {}) :
        self.database = database
        
        #self.mainWindow()

        """ self.show_Students()
        self.modify_Student() """

    #<== Checker board For localization of columns and rows ==>
    def CheckerBoard(self,window):
        #<== Values y - width | h - height | color1 - first color | color2 - second color
        y = 8
        h = 1
        color1 = "yellow"
        color2 = "red"

        #<== Creating labels for references ==>
        for i in range(8):
            if i%2 == 1:
                tk.Label(window,text=f"{i}",width=y,height=h,background=color1).grid(column = i, row = 0)
            else:
                tk.Label(window,text=f"{i}",width=y,height=h,background=color2).grid(column = i, row = 0)
        for i in range(1,8):
            if i%2 == 1:
                tk.Label(window,text=f"{i}",width=y,height=h,background=color1).grid(column = 0, row = i)
            else:
                tk.Label(window,text=f"{i}",width=y,height=h,background=color2).grid(column = 0, row = i)

    def table_Window(self):        
        table_Window = tk.Tk()
        #<== Establishing connection with database ==>
        database_Connection = msqlc.connect(
            host     = self.database['host'],
            user     = self.database['user'],
            password = self.database['psswd'],
            database = self.database['database']
        )
        
        database_Cursor = database_Connection.cursor()

        #<== Query for reciving all table names in our database ==>
        query1 = f"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'students';"

        database_Cursor.execute(query1)
        database_Answer = database_Cursor.fetchall()
        
        #<== Creation Dropbox for specific table display ==>
        default = 'Choose Table'
        cho = StringVar(value = default)
        dropbox = tk.OptionMenu(table_Window,cho,*database_Answer)
        dropbox.grid(column= 6 , row = 1, columnspan = 2) 

        table_Name = cho.get()
        print(table_Name)
        #<== Verification if choosen any option other than default ==>
        #if table_Name != default:
            #<== Query for reciving all column names in our table
        database_Cursor = database_Connection.cursor()
        query2 = f"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'{table_Name}';"

        database_Cursor.execute(query2)
        database_Answer = database_Cursor.fetchall()
            
        

        print("hello")
        tk.Button(table_Window,command= self.mainWindow).grid(column=2 , row = 2)
        table_Window.mainloop()

    #<== Main window elements ==>
    def mainWindow(self):
        self.main_Window = tk.Tk()

        self.CheckerBoard(self.main_Window)

        #<== Dictionary with input fields ==>
        self.inputs = {
            'Imie'      : tk.Entry(self.main_Window),
            'Nazwisko'  : tk.Entry(self.main_Window),
            'Adres'     : tk.Entry(self.main_Window),
            'Pesel'     : tk.Entry(self.main_Window),
            'Album'     : tk.Entry(self.main_Window),
        }

        #<== Asigning position for Elements of dictionary ==>
        self.col = 1
        self.row = 1
        for i in self.inputs:
            tk.Label(self.main_Window,text=f'{i}').grid(column = self.col, row = self.row,columnspan=2)
            self.inputs[i].grid(column = self.col + 2, row = self.row , columnspan=3)
            self.row += 1

        #<== Button and Resoult Label ==>
        button = tk.Button(self.main_Window, text = "Dodaj Studenta", command = self.add_Student)
        button.grid(column = 3, row = self.row, columnspan=2)
        self.row += 1
        self.resoult = tk.Label(self.main_Window,text = 'x')
        self.resoult.grid(column = self.col, row = self.row)

        self.modify_Student()

        self.main_Window.mainloop()

    #<== Function for handling displaying elemnts in table ==>
    def show_Students(self):
        output = self.resoult

        query = "select * from students_data"
        
        #<== Establishing connection with database ==>
        database_Connection = msqlc.connect(
            host     = self.database['host'],
            user     = self.database['user'],
            password = self.database['psswd'],
            database = self.database['database']
        )
        
        database_Cursor = database_Connection.cursor()

        database_Cursor.execute(query)
        database_Answer = database_Cursor.fetchall()

        output.config(text = f"{database_Answer}")
        database_Connection.close()
        



    def add_Student(self):
        database_Connection = msqlc.connect(
            host     = self.database['host'],
            user     = self.database['user'],
            password = self.database['psswd'],
            database = self.database['database']
        )
        database_Cursor = database_Connection.cursor()

        form = self.inputs
        values = f"'{form['Imie'].get()}','{form['Nazwisko'].get()}','{form['Adres'].get()}','{form['Pesel'].get()}','{form['Album'].get()}'"
        query = f"INSERT INTO `students_data`(`Name`, `Surname`, `Adress`, `PESEL`, `Album`) VALUES ({values})"
        
        database_Cursor.execute(query)
        database_Connection.commit()
        database_Connection.close()

        self.show_Students()

    def modify_Student(self):
        database_Connection = msqlc.connect(
            host     = self.database['host'],
            user     = self.database['user'],
            password = self.database['psswd'],
            database = self.database['database']
        )
        database_Cursor = database_Connection.cursor()

        form = self.inputs
        database_Cursor.execute("SELECT `ID` FROM `students_data` WHERE `ID` > 0;")
        database_Answer = database_Cursor.fetchall()        
        
        cho = StringVar(value = '0')
        dropbox = tk.OptionMenu(self.main_Window,cho,*database_Answer)
        dropbox.grid(column= 6 , row = 1, columnspan = 2) 

        values = [
            form['Imie'].get(),
            form['Nazwisko'].get(),
            form['Adres'].get(),
            form['Pesel'].get(),
            form['Album'].get(),
        ]

        query = f"UPDATE `students_data` SET `Name`='{values[0]}',`Surname`='{values[1]}',`Adress`='{values[2]}',`PESEL`='{values[3]}',`Album`='{values[4]}' WHERE `ID` = {int(cho.get())}"
        tk.Button(self.main_Window,text="modify",command= lambda:
                  database_Cursor.execute(query).commit()).grid(column=3,row=7,columnspan=2)
        database_Connection.close()


x = App(connection_Data)
x.table_Window()



