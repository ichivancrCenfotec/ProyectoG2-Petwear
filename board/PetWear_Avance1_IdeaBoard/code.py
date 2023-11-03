print("---PETWEAR IDEABOARD---")
# Codigo para DHT11
# SPDX-FileCopyrightText: 2017 Limor Fried for Adafruit Industries
# Modificado por Jefry Valverde y Gabriela Urbina
# Universidad CENFOTEC
#
# SPDX-License-Identifier: MIT

import time
import keypad
import adafruit_dht
import board
from ideaboard import IdeaBoard

ib = IdeaBoard()

dht = adafruit_dht.DHT11(board.IO32)
keys=keypad.Keys((board.IO27,),value_when_pressed=False)
estado=False

while True:
    try:
        temperature = dht.temperature
        humidity = dht.humidity
        event = keys.events.get()
        if event:
            if event.pressed:
                estado= not estado
                if estado:
                    ib.pixel=(255,0,255)
        # Print what we got to the REPL
                    print("Temp: {:.1f} *C \t Humidity: {}%".format(temperature, humidity))
                else:
                    ib.pixel=(0,0,0)
    except RuntimeError as e:
        # Reading doesn't always work! Just print error and we'll try again
        print("Reading from DHT failure: ", e.args)

    time.sleep(1)