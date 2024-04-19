import tkinter
import requests

window = tkinter.Tk()
window.title("Login")

icon = tkinter.PhotoImage(file = "icon.png")

label = tkinter.Label(window, image = icon)
label.pack()

def handle_login():
    
    username = username_entry.get()
    password = password_entry.get()

    
    response = requests.post("http://localhost:5213/api/operadores", json={"usuario": username, "contraseña": password})

    print(response.json())
    
    if response.status_code == 200:
        
        window.destroy()
    else:
        
        error_label.config(text="Invalid username or password")


username_label = tkinter.Label(window, text="Username")
username_label.pack()
username_entry = tkinter.Entry(window)
username_entry.pack()


password_label = tkinter.Label(window, text="Password")
password_label.pack()
password_entry = tkinter.Entry(window, show="*")
password_entry.pack()


login_button = tkinter.Button(window, text="Login", command=handle_login)
login_button.pack()


error_label = tkinter.Label(window, text="")
error_label.pack()


window.mainloop()