class House:
    def __init__(self, ID, street_ID, size, is_being_lived, gaz_connected, water_connected, electricity_connected):
        self.ID = ID
        self.street_ID = street_ID
        self.size = size
        self.is_being_lived = is_being_lived
        self.gaz_connected = gaz_connected
        self.water_connected = water_connected
        self.electricity_connected = electricity_connected

class Street:
    def __init__(self, ID, name, length):
        self.ID = ID
        self.name = name
        self.length = length

class SHConnection:
    def __init__(self, house_ID, street_ID):
        self.house_ID = house_ID
        self.street_ID = street_ID

Streets = [Street(1, "Ленина", 2),
           Street(2, "Сталина", 32),
           Street(3, "оленя", 22),
           Street(4, "Кеннеди", 17),
           Street(5, "бобра", 9)]

def FindStreetByID(ID):
    global Streets
    for i in Streets:
        if i.ID == ID:
            return i

Houses = [House(1, 1, 45, True, True, True, True),
          House(2, 1, 25, True, False, True, True),
          House(3, 2, 17, True, True, True, True),
          House(4, 2, 128, True, True, False, True),
          House(5, 3, 280, True, False, True, True),
          House(6, 4, 67, True, True, True, False)]

def FindHouseByID(ID):
    global Houses
    for i in Houses:
        if i.ID == ID:
            return i

SHConnections = [SHConnection(1, 1),
                 SHConnection(13 % 5, 52 % 6),
                 SHConnection(3, 1),
                 SHConnection(19 % 5, 73 % 6),
                 SHConnection(4, 3),
                 SHConnection(3, 3),
                 SHConnection(5, 2)]

def NamedByNameStreets():
    for i in Streets:
        if (i.name[0].isupper()):
            print(i.ID, "-", i.name)

def AverageHousesArea():
    AreaSum = {}
    AreaQuantity = {}
    for i in Houses:
        AreaSum[i.street_ID] = AreaSum.get(i.street_ID, 0) + i.size
        AreaQuantity[i.street_ID] = AreaQuantity.get(i.street_ID, 0) + 1
    Result = {i: AreaSum[i] / AreaQuantity[i] for i in AreaSum.keys()}
    for i in Result.keys():
        print(FindStreetByID(i).name, "-", Result[i])

def HousesWithGaz():
    for i in SHConnections:
        if (FindHouseByID(i.house_ID).gaz_connected):
            print(FindHouseByID(i.house_ID).ID, "-", FindStreetByID(i.street_ID).name)

print("ID и названия улиц, названных в честь человека:")
NamedByNameStreets()
print()
print("Средняя площадь домов на каждой улице:")
AverageHousesArea()
print()
print("ID домов с газом и относящиеся к ним улицы:")
HousesWithGaz()

