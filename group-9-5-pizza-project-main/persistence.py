import os
import pickle

def store(orders, id):
    with open("dict.pickle", "wb") as f:
        pickle.dump((orders, id), f)

def recover(): # returns a list of orders
    if not os.path.exists("dict.pickle"):
        return [], 0
    with open("dict.pickle", "rb") as f:
        return pickle.load(f)