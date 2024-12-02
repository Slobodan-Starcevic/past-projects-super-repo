import itertools

class Pizza():
    id_iter = itertools.count(1)
    def __init__(self, name : str):
        self.id = next(self.id_iter)
        self.name = name
        self.status = 'Preparing'

        match(name):
            case 'margherita':
                self.price = 15
                self.cooktime = 20
                self.img = '/static/resources/margherita.jpg'
            case 'pepperoni':
                self.price = 10
                self.cooktime = 18
                self.img = '/static/resources/pepperoni.jpg'
            case 'hawaii':
                self.price = 12
                self.cooktime = 15
                self.img = '/static/resources/hawaii.jpg'
            case 'cheeselover':
                self.price = 13
                self.cooktime = 20
                self.img = '/static/resources/cheeselover.png'
            case 'meatlover':
                self.price = 14
                self.cooktime = 16
                self.img = '/static/resources/meatlover.jpg'
            case _:
                self.price = 0
                self.cooktime = 0
                self.img = ''

    def start_cooking(self):
        self.status = 'Cooking'

    def finish_cooking(self):
        self.status = 'Ready'

class Order():
    def __init__(self, id):
        self.id = id
        self.price = 0
        self.items = []
        self.status = 'Preparing'

    def get_price(self):
        return sum(item.price for item in self.items)

    def add_item(self, item):
        self.items.append(item)

    def check_status(self):
        ready = True
        for item in self.items:
            if item.status != 'Ready':
                ready = False
        
        if ready:
            self.status = 'Ready'
        
        return self.status