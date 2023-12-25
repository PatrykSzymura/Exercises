import requests

response = requests.get("https://10.242.100.100/wol/?pc=ryzen?")

print(response.status_code)
