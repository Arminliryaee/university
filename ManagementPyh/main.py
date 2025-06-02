from Services.Inventory import Inventory
from Models.Product import Product


def main():
    inventory = Inventory()

    while True:
        print("\n===== سیستم مدیریت انبار =====")
        print("1. افزودن کالا")
        print("2. ویرایش کالا")
        print("3. حذف کالا")
        print("4. نمایش لیست کالاها")
        print("5. جستجوی کالا")
        print("6. خروجی گرفتن از لیست کالاها")
        print("7. خروج")

        choice = input("انتخاب شما: ")

        if choice == '1':
            code = input("کد کالا: ")
            name = input("نام کالا: ")
            price = float(input("قیمت: "))
            quantity = int(input("تعداد: "))
            description = input("توضیحات (اختیاری): ")
            product = Product(code, name, price, quantity, description)
            inventory.add_product(product)

        elif choice == '2':
            code = input("کد کالای مورد نظر برای ویرایش: ")
            print("فقط مقادیری که می‌خواهید تغییر دهید وارد کنید، بقیه را خالی بگذارید.")
            name = input("نام جدید: ")
            price = input("قیمت جدید: ")
            quantity = input("تعداد جدید: ")
            description = input("توضیحات جدید: ")

            update_data = {}
            if name: update_data['name'] = name
            if price: update_data['price'] = float(price)
            if quantity: update_data['quantity'] = int(quantity)
            if description: update_data['description'] = description

            inventory.update_product(code, **update_data)

        elif choice == '3':
            code = input("کد کالای مورد نظر برای حذف: ")
            inventory.delete_product(code)

        elif choice == '4':
            inventory.list_products()

        elif choice == '5':
            keyword = input("عبارت جستجو (نام یا کد): ")
            inventory.search_products(keyword)

        elif choice == '6':
            filename = input("نام فایل برای ذخیره گزارش (مثلاً report.txt): ")
            inventory.export_to_file(filename)

        elif choice == '7':
            print("خروج از برنامه.")
            break

        else:
            print("گزینه نامعتبر است. لطفاً دوباره تلاش کنید.")


if __name__ == '__main__':
    main()
