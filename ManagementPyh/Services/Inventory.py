import json
import os
from tabulate import tabulate
from Models.Product import Product


class Inventory:
    def __init__(self, data_file='inventory.json'):
        self.data_file = data_file
        self.products = self.load_data()

    def load_data(self):
        if not os.path.exists(self.data_file):
            return []
        with open(self.data_file, 'r') as f:
            data = json.load(f)
            return [Product.from_dict(item) for item in data]

    def save_data(self):
        with open(self.data_file, 'w') as f:
            json.dump([p.to_dict() for p in self.products], f, indent=4)

    def add_product(self, product):
        if self.get_product_by_code(product.code):
            print("کالا با این کد قبلاً ثبت شده است.")
            return
        self.products.append(product)
        self.save_data()
        print("کالا با موفقیت اضافه شد.")

    def update_product(self, code, **kwargs):
        product = self.get_product_by_code(code)
        if not product:
            print("کالایی با این کد پیدا نشد.")
            return
        for key, value in kwargs.items():
            if hasattr(product, key):
                setattr(product, key, value)
        self.save_data()
        print("کالا با موفقیت به‌روزرسانی شد.")

    def delete_product(self, code):
        product = self.get_product_by_code(code)
        if product:
            self.products.remove(product)
            self.save_data()
            print("کالا با موفقیت حذف شد.")
        else:
            print("کالایی با این کد یافت نشد.")

    def list_products(self):
        if not self.products:
            print("هیچ کالایی در انبار وجود ندارد.")
            return

        table = [[p.code, p.name, p.price, p.quantity, p.description] for p in self.products]
        headers = ["توضیحات", "تعداد", "قیمت", "نام", "کد"]
        print(tabulate(table, headers=headers, tablefmt="grid", stralign='center', numalign='center'))

    def get_product_by_code(self, code):
        for product in self.products:
            if product.code == code:
                return product
        return None

    def search_products(self, keyword):
        results = [p for p in self.products if keyword.lower() in p.name.lower() or keyword.lower() in p.code.lower()]
        if results:
            print("\nنتایج جستجو:")
            for product in results:
                print(product)
        else:
            print("هیچ کالایی با این مشخصات پیدا نشد.")

    def export_to_file(self, filename):
        with open(filename, 'w', encoding='utf-8') as f:
            for p in self.products:
                f.write(str(p) + '\n')
        print(f"گزارش به فایل '{filename}' ذخیره شد.")
