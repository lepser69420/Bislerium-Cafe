# importing datetime and date for time and date used while billing
import datetime
from datetime import date
import random

x = datetime.datetime.now()

my_file = open("costume.txt", "r")
data = my_file.read()
data_into_list = data.replace('\n', '').split(",")
# print(data_into_list)
my_file.close()
# print(data_into_list[0])

no_of_suit1 = 0
no_of_suit2 = 0
no_of_suit3 = 0

def costumes():
    print(f'''
    the available dresses are
    sn  item            no      price
    1. cop suit         {data_into_list[3]}	    {data_into_list[2]}
    2. suit             {data_into_list[7]}	    {data_into_list[6]}
    3. fairy dress      {data_into_list[11]}	    {data_into_list[10]}
    please type 4 for bill
    please type 5 to exit the program
    ''')

def rent():
    global no_of_suit1,no_of_suit2,no_of_suit3
    costumes()
    condition = True
    while condition:
        try:
            number = input("SN of the costume you want to rent: ")
            if number == "1":
                no_of_suit1 = int(input(f"Number of {data_into_list[0]} you want to rent: "))
                if no_of_suit3 > int(data_into_list[3]):
                    print("We don't have that much on the stock.")
                    no_of_suit1 = 0
                elif no_of_suit1 <0:
                    print("Insert number more than zero.")
                else:
                    data_into_list[3] = int(data_into_list[3]) - no_of_suit1
                # print(data_into_list[3])
            elif number == "2":
                no_of_suit2 = int(input(f"Number of {data_into_list[4]} you want to rent: "))
                if no_of_suit3 > int(data_into_list[7]):
                    print("We don't have that much on the stock.")
                    no_of_suit2 = 0
                elif no_of_suit2 <0:
                    print("Insert number more than zero.")
                else:
                    data_into_list[7] = int(data_into_list[7]) - no_of_suit2
                # print(data_into_list[7])
            elif number == "3":
                no_of_suit3 = int(input(f"Number of {data_into_list[8]} you want to rent: "))
                if no_of_suit3 > int(data_into_list[11]):
                    print("We don't have that much on the stock.")
                    no_of_suit1 = 0
                elif no_of_suit3 <0:
                    print("Insert number more than zero.")
                else:
                    data_into_list[11] = int(data_into_list[11]) - no_of_suit3
                # print(data_into_list[11])
            elif number == "4":
                bill()
                print("Your bill has been created.")
            elif number == "5":

                break
            else:
                print("Please type the sn no correctly.")
        except:
            print("Please check the value.")
# rent()


def restore():
    global no_of_suit1, no_of_suit2, no_of_suit3
    costumes()
    condition = True
    while condition:
        try:
            number = input("SN of the dress you want to return: ")
            costumes()
            if number == "1":
                no_of_suit1 = int(input(f"Number of {data_into_list[0]} you want to return: "))
                data_into_list[3] = int(data_into_list[3]) + no_of_suit1
            elif number == "2":
                no_of_suit2 = int(input(f"Number of {data_into_list[4]} you want to return: "))
                data_into_list[7] = int(data_into_list[7]) + no_of_suit2
            elif number == "3":
                no_of_suit3 = int(input(f"Number of {data_into_list[8]} you want to return: "))
                data_into_list[11] = int(data_into_list[11]) + no_of_suit3
            elif number == "4":
                rbill()
                print("Your bill has been created.")
            elif number == "5":
                break
            else:
                print("Please type the sn no correctly.")
        except:
            print("please enter the correct value.")


def bill():
    global x,no_of_suit1,no_of_suit2,no_of_suit3
    name = input("Enter your name: ")
    # x = datetime.datetime.now()
    tc = no_of_suit1 * float(data_into_list[2])
    ts = no_of_suit2 * float(data_into_list[6])
    tf = no_of_suit3 * float(data_into_list[11])
    t = ts + tf + tc  # all total
    time = x.strftime("%I:%M %p")  # time of billing with 12hr format
    d = date.today()  # date of billing
    y = d + datetime.timedelta(days=5)  # date after which file will be added
    bill = open(f"{name}.txt", "a")  # opening the billing file with append mode
    bill.write(
        f'''
  COURSEWORK COSTUME RENTAL
             DATE:{d}
             TIME:{time}
             Name:{name}
             sn  item	no     price    total
             1. cop suit	{no_of_suit1}	{data_into_list[2]}	{tc}
             2. suit		{no_of_suit2}	{data_into_list[6]}	{ts}
             3. fairy dress	{no_of_suit3}	{data_into_list[11]}	{tf}
             total				{t}


you are kindly informed to return the costume
before {time} at {y}.
After that you have to pay 5% of the total
amount as fine perday.

Thankyou! visit again.
'''
    )


def rbill():
    global x, no_of_suit1, no_of_suit2, no_of_suit3
    name = input("Enter your name: ")
    diffdate = int(input("no of day you rented the dress: "))
    # x = datetime.datetime.now()
    tc = no_of_suit1 * float(data_into_list[2])
    ts = no_of_suit2 * float(data_into_list[6])
    tf = no_of_suit3 * float(data_into_list[10])
    t = ts + tf + tc
    time = x.strftime("%I:%M %p")
    d = date.today()
    y = d + datetime.timedelta(days=5)
    bill = open(f"{random.randint(1, 999)}.txt", "a")
    dif = diffdate - 5
    if dif > 0:
        bill.write(
            f'''
                 COURSEWORK COSTUME RENTAL
                 DATE:{d}
                 TIME:{time}
                 Name:{name}
                 sn  item	no     price    total
                 1. cop suit	{no_of_suit1}	{data_into_list[2]}	{tc}
                 2. suit		{no_of_suit2}	{data_into_list[6]}	{ts}
                 3. fairy dress	{no_of_suit3}	{data_into_list[11]}	{tf}
                 total				{t}

                 your fine amount for {dif} day/days after the
                 5 days deadline with 5% fine will be
                 fine amount = {5 / 100 * dif * t}
                 total amount (rental + fine) = {t + 5 / 100 * dif * t}
                 Thankyou! visit again.
                 '''
        )
    elif dif < 0:
        bill.write(
            f'''
                 COURSEWORK COSTUME RENTAL
                 DATE:{d}
                 TIME:{time}
                 Name:{name}
                 sn  item	no     price    total
                 1. cop suit	{no_of_suit1}	{data_into_list[2]}	{tc}
                 2. suit		{no_of_suit2}	{data_into_list[6]}	{ts}
                 3. fairy dress	{no_of_suit3}	{data_into_list[11]}	{tf}
                 total				{t}

                 Thankyou! visit again.
                 ''')

def stock():
    with open("costume.txt", "r+") as file:
        file.truncate()
    with open("dress.txt", "a") as f:
        f.write(data_into_list)
def work():
    condition = True
    while condition:
        input1 = input("Press 1 to rent and 2 to return the costume: ")
        try:
            if input1 == "1":
                rent()
            elif input1 == "2":
                restore()
            else:
                print("Please type 1 to rent and 2 to return.")
        except:
            print("Please type the correct number.")


work()
