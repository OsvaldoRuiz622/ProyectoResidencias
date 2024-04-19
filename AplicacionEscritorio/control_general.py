import tkinter as tk
import requests

class ControlGeneralApi(tk.Toplevel):
    def __init__(self, parent):
        super().__init__(parent)
        self.parent = parent
        self.title("Control General API")

        self.table_frame = tk.Frame(self)
        self.table_frame.pack(fill="both", expand=True)

        self.headers = ["Column 1", "Column 2", "Column 3", "Column 4", "Column 5", "Column 5", "Column 5", "Column 5", "Column 5"]
        self.header_labels = [tk.Label(self.table_frame, text=header, width=10, anchor="center") for header in self.headers]
        for i, label in enumerate(self.header_labels):
            label.grid(row=0, column=i, padx=5, pady=5)

        self.rows = []
        for i in range(11):
            row = [tk.Label(self.table_frame, text="", width=10, anchor="center") for _ in range(len(self.headers))]
            for j, label in enumerate(row):
                label.grid(row=i+1, column=j, padx=5, pady=5)
            self.rows.append(row)

        self.fetch_api_data()

    def fetch_api_data(self):
        response = requests.get("https://api.example.com/data")

        if response.status_code == 200:
            data = response.json()

            for i, row_data in enumerate(data):
                for j, value in enumerate(row_data.values()):
                    self.rows[i][j]["text"] = str(value)
        else:
            # Handle the error
            print(f"Error: {response.status_code}")