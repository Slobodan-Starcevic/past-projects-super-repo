from flask import Flask, request, redirect, render_template
import classes as c
import persistence

app = Flask(__name__)
id = 0

orders, id = persistence.recover()


@app.route("/")
def main():
    return render_template('home.html')

@app.route("/order")
def order_page():
    return render_template('order.html')

@app.route("/about")
def about_page():
    return render_template('about.html')

@app.route("/kitchen")
def luigi_page():
    return render_template('luigi.html', orders = orders)

@app.post('/register')
def add_order():
    pepperoni = int(request.form['pepperoni_amount'])
    margherita = int(request.form['margherita_amount'])
    hawaii = int(request.form['hawaii_amount'])
    cheeselover = int(request.form['cheeselover_amount'])
    meatlover = int(request.form['meatlover_amount'])
    
    if pepperoni or margherita or hawaii or cheeselover or meatlover > 0:
        global id
        id += 1
        new_order = c.Order(id)

        for i in range(pepperoni):
            new_pizza = c.Pizza('pepperoni')
            new_order.add_item(new_pizza)

        for i in range(margherita):
            new_pizza = c.Pizza('margherita')
            new_order.add_item(new_pizza)
        
        for i in range(hawaii):
            new_pizza = c.Pizza('hawaii')
            new_order.add_item(new_pizza)

        for i in range(cheeselover):
            new_pizza = c.Pizza('cheeselover')
            new_order.add_item(new_pizza)

        for i in range(meatlover):
            new_pizza = c.Pizza('meatlover')
            new_order.add_item(new_pizza)

        orders.append(new_order)
        persistence.store(orders, id)
        return redirect(f"/order_status/{new_order.id}")
    
    return render_template('order.html')

@app.get("/order_status/<int:order_id>")
def order_status(order_id):
    for itr_order in orders:
        if itr_order.id == order_id:
            return render_template("order_status.html", order = itr_order)
    return redirect('/')

@app.get('/api/item/take')
def cook_pizza():
    for order in orders:
        for pizza in order.items:
            if pizza.status == 'Preparing':
                pizza.start_cooking()
                persistence.store(orders, id)
                return {"cook_time": pizza.cooktime, "id": pizza.id}
    return "No pizzas", 503

@app.post('/api/item/<int:id>/complete')
def complete_pizza(id):
    for order in orders:
        for pizza in order.items:
            if pizza.id == id:
                pizza.finish_cooking()
                persistence.store(orders, id)
                return 'ok'
    return 'error', 404