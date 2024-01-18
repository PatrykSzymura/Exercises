from tkinter import *
from tkinter import ttk
import tkinter as tk


import sqlite3 as sql
from sqlite3 import Error

# <== Class for managing database queries ==>
class db():
    def __init__(self, database_Name = ""):
        self.database_Name = database_Name

    # <== for queries like select ==>
    def show(self, query = ""):
        database_Connection = sql.connect(self.database_Name)
        database_Cursor = database_Connection.cursor()

        database_Cursor.execute(query)
        database_Answer = database_Cursor.fetchall()
        database_Connection.close()

        return database_Answer
    
    # <== for queries like insert or update ==>
    def edit(self, query = ""):
        database_Connection = sql.connect(self.database_Name)
        database_Cursor = database_Connection.cursor()

        database_Cursor.execute(query)
        database_Connection.commit()
        database_Connection.close()

    def set_Database_Dictionary(self):
        
        database_Connection = sql.connect(self.database_Name)
        database_Cursor = database_Connection.cursor()
        database_Cursor.execute("SELECT name FROM sqlite_master WHERE type='table';")
        database_Answer  = database_Cursor.fetchall()

        database_Dictionary = {}
        
        for table in database_Answer :
            table = table[0]
            
            database_Cursor.execute(f"PRAGMA table_info({table});")
            
            columns = database_Cursor.fetchall()
            
            database_Dictionary[table] = [column[1] for column in columns]

        database_Connection.close()

        return database_Dictionary

# <== Class for handling aplication components ==>
class Components():
    def __init__(self, main_Window, database_Name):
        self.main_Window = main_Window
        self.database_Name = database_Name

    def display_data(self,tree, table_name,dictionary, positionX = 1, positionY = 1,query = ""):
        columns  = dictionary[table_name]

        # <== Set up the Treeview with columns ==>
        tree["columns"] = columns
        for column in columns:
            tree.heading(column, text=column)
            tree.column(column, anchor="center", width=75)

        # <== Fetch and display data ==>
        
        data = db(self.database_Name).show(query)

        for row in data:
            tree.insert("", "end", values=row)

        # <== Display the Treeview ==>
        tree.grid(column = positionX, row = positionY, columnspan = 9, rowspan = 4)

    def dropbox(self,default_Option = "",options = {},positionX = 1, positionY = 1):
        choice = StringVar(value = default_Option)
        dropbox = tk.OptionMenu(self.main_Window, choice, *options)
        dropbox.grid(column = positionX , row = positionY, columnspan = 2)
        return choice.get()

class App():
    def __init__(self,database_Name):
        self.database_Name = database_Name
        self.database_Dictionary = db(self.database_Name).set_Database_Dictionary()

        self.table_Window()        
    
    def form_Window(self,option):
        formWindow = tk.Tk()
        formWindow.title(f'{option}')

        form = {
            'Id'        : tk.Entry(formWindow),
            'Imie'      : tk.Entry(formWindow),
            'Nazwisko'  : tk.Entry(formWindow),
            'Adres'     : tk.Entry(formWindow),
            'Pesel'     : tk.Entry(formWindow),
            'Album'     : tk.Entry(formWindow),
        }

        col = 1
        row = 1
        for i in form:
            tk.Label(formWindow,text=f'{i}').grid(column = col, row = row,columnspan=2)
            form[i].grid(column = col + 2, row = row , columnspan=3)
            row += 1

        if   option == 'modify':
            pass
        elif option == 'add':
            formWindow.title(f'{option}')
            form['Id'].config(state= "disabled")

        guzior = Button(formWindow, text=option, command=lambda opt=option: self.handle_Button(opt, form))

        guzior.grid(column=3,row=7)
        
        formWindow.mainloop()

    def handle_Button(self,option,form):
        if option == 'add':
            values = f"'{form['Imie'].get()}','{form['Nazwisko'].get()}','{form['Adres'].get()}','{form['Pesel'].get()}','{form['Album'].get()}'"
            query = f"INSERT INTO `students_data`(`Name`, `Surname`, `Adress`, `PESEL`, `Album`) VALUES ({values})"
            db(self.database_Name).edit(query)
        elif option == 'mod':
            query = f"UPDATE `students_data` SET `Name`='{form['Imie'].get()}', `Surname`='{form['Nazwisko'].get()}', `Adress`='{form['Adress'].get()}', `PESEL`='{form['Pesel'].get()}', `Album`='{form['Album'].get()}' WHERE `id` = {int(form['Id'].get())}"
    
    def table_Window(self):
        tableWindow = tk.Tk()
        cmp = Components(tableWindow,self.database_Name)
        tree = ttk.Treeview(tableWindow,show='headings')
        tableWindow.title("Table Window")

        #self.CheckerBoard(tableWindow,height=4)

        choice = StringVar()
        default = 'students_data'
        choice.set(default)
        dropbox1 = tk.OptionMenu(tableWindow, choice, *self.database_Dictionary.keys(), command= lambda choice=choice: 
                                cmp.display_data(tree,choice, self.database_Dictionary, positionY=2))
        dropbox1.grid(column = 1 , row = 1, columnspan = 2)
        
            
        query = f"SELECT * FROM {choice.get()};"
        cmp.display_data(tree,choice.get(),self.database_Dictionary,query = query, positionY = 2)

        Button(tableWindow,text="Add",width = 8,command = lambda: self.form_Window('add')).grid(column=1,row=6)
        Button(tableWindow,text="Modify",width = 8,command = lambda: self.form_Window('modify')).grid(column=2,row=6)
        




         


        tableWindow.mainloop()

    #<== Checker board For localization of columns and rows ==>
    def CheckerBoard(self,window,height = 1,width = 8):
    
        color1 = "yellow"
        color2 = "red"

        #<== Creating labels for references ==>
        for i in range(10):
            if i%2 == 1:
                tk.Label(window,text=f"{i}",width=width,height=height,background=color1).grid(column = i, row = 0)
            else:
                tk.Label(window,text=f"{i}",width=width,height=height,background=color2).grid(column = i, row = 0)
        for i in range(1,8):
            if i%2 == 1:
                tk.Label(window,text=f"{i}",width=width,height=height,background=color1).grid(column = 0, row = i)
            else:
                tk.Label(window,text=f"{i}",width=width,height=height,background=color2).grid(column = 0, row = i)

App('database.db')

