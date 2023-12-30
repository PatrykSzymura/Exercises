from sklearn import datasets
import pandas as pd 
import numpy as np 

iris = datasets.load_iris()
print(iris.keys())

class Kartoteka:
    def __init__(self,x = []):
        self.dictionary = {}
        for name in x:
            self.dictionary[name] = None
        



tmp  = Kartoteka(iris.keys())
print(iris)