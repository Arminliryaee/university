class Product:
    def __init__(self, code: str, name: str, price: float, quantity: int, description: str = ""):
        self.code = code
        self.name = name
        self.price = price
        self.quantity = quantity
        self.description = description

    def to_dict(self):
        return {
            "code": self.code,
            "name": self.name,
            "price": self.price,
            "quantity": self.quantity,
            "description": self.description,
        }

    @staticmethod
    def from_dict(data: dict):
        return Product(
            code=data["code"],
            name=data["name"],
            price=data["price"],
            quantity=data["quantity"],
            description=data.get("description", "")
        )

    def __str__(self):
        return f"{self.code} | {self.name} | {self.price} | {self.quantity} | {self.description}"