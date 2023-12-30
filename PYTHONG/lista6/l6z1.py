import tkinter as tk
import sqlite3

class App:
    def __init__(self,database = "DatabaseName") :
        self.database = database

        main_Window = tk.Tk()

        self.inputs = {
            'Imie'      : tk.Entry(main_Window),
            'Nazwisko'  : tk.Entry(main_Window),
            'Adres'     : tk.Entry(main_Window),
            'Pesel'     : tk.Entry(main_Window),
            'Album'     : tk.Entry(main_Window),
        }


        col = 0
        row = 0
        for i in self.inputs:
            tk.Label(main_Window,text=f'{i}').grid(column = col, row = row)
            self.inputs[i].grid(column = col + 1, row = row)
            row += 1

        button = tk.Button(main_Window, text = "Dodaj Studenta")

        main_Window.mainloop()

    def add_Student(self):
        values = self.inputs

        database_Connection = sqlite3.connect(self.database)
        database_Cursor = database_Connection.cursor()

        database_Cursor.execute("Insert into studenci values (:p_imie,:p_nazwisko,:p_adres,:p_pesel,:p_album)",
                                {
                                    'p_imie' :      values['Imie'].get(),
                                    'p_nazwisko' :  values['Nazwisko'].get(),
                                    'p_adres' :     values['Adres'].get(),
                                    'p_pesel' :     values['Pesel'].get(),
                                    'p_album' :     values['Album'].get()
                                })
        database_Connection.commit()
        database_Connection.close()

x = App("database")

