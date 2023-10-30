import time
import ssl
import socketpool
import wifi
import adafruit_minimqtt.adafruit_minimqtt as MQTT
import board
from ideaboard import IdeaBoard

ib = IdeaBoard()

try:
    from secrets import secrets
except ImportError:
    print("WiFi secrets are kept in secrets.py, please add them th...")
    raise

print("Connecting to %s" % secrets["ssid"])
wifi.radio.connect(secrets["ssid"], secrets["password"])
print("Connected to %s!" % secrets["ssid"])

### Topic Setup ###

mqtt_topic = "pruebas"

### Code ###
def connect(mqtt_client, userdata, flags, rc):
    print("Connected to MQTT Broker!")
    print("Flags: {0}\n RC:{1}".format(flags, rc))
    
def disconnect(mqtt_client, userdata, rc):
    print("Disconnected from MQTT Broker!")

def subscribe(mqtt_client,userdata,topic, granted_qos):
    print("Subscribed to {0} with QOS level {1}".format(topic,granted_qos))
    
def unsubscribe(mqtt_client,userdata,topic,pid):
    print("Unsubscribed from {0} with PID {1}".format(topic,pid))
        
def publish(mqtt_client,userdata,topic,pid):
     print("Published to {0} with PID {1}".format(topic,pid))
     
def message(client,topic,message):
    print("New message on topic {0}: {1}".format(topic,message))
    if topic == "pruebas/comandos":
        if message == "ON":
            ib.pixel = (0,0,225)
        elif message == "OFF":
            ib.pixel = (0,0,0)

pool=socketpool.SocketPool(wifi.radio)

mqtt_client= MQTT.MQTT(
    broker=secrets["broker"],
    port=secrets["port"],
    socket_pool=pool,
    ssl_context=ssl.create_default_context(),
    )

mqtt_client.on_connect = connect
mqtt_client.on_disconnect = disconnect
mqtt_client.on_subscribe = subscribe
mqtt_client.on_unsubscribe = unsubscribe
mqtt_client.on_publish = publish
mqtt_client.on_message = message

print("Attempting to connect to %s" % mqtt_client.broker)
mqtt_client.connect()

print("Subscribing to pruebas/comandos")
mqtt_client.subscribe("pruebas/comandos")


ultimo = 0
while True:
    mqtt_client.loop()
    ahora = time.monotonic()
    if ahora - ultimo > 10:
        mqtt_client.publish("pruebas/datos", "Hola Mundo!")
        ultimo = ahora