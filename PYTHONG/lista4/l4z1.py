import requests
#program zapamiętuje ustawienie miasta aktualna czy na jutro czy takie samo zapytanie
API_key = "6e9f9d3c237d63c3352458cf75b21a82"
def Get_Coordinates(city_name , api_key="API_KEY", limit=1):
    url_Geo = "http://api.openweathermap.org/geo/1.0/direct"
    params = {"q": city_name, "limit": limit, "appid": api_key}
    try:
        response = requests.get(url_Geo, params=params)
        data = response.json()
        if data:
            res = {}
            res.update({"lat" : data[0]["lat"]})
            res.update({"lon" : data[0]["lon"]})
            return res
        else:
            print("No data found for the specified city.")
            return None
    except requests.exceptions.RequestException as error:
        print(f"Error making API request: {error}")
        return None
def Get_Weather(when,city_name,api_key):
    coordinates = Get_Coordinates(city_name,api_key)
    url_Weather_Today = f"https://api.openweathermap.org/data/2.5/weather"
    params_Today = {"lat": coordinates["lat"], "lon": coordinates["lon"],"units": "metric", "appid": api_key}
    url_Weather_Tomorrow = f"https://api.openweathermap.org/data/2.5/forecast?"
    params_Tomorrow = {"lat": coordinates["lat"], "lon": coordinates["lon"],"units": "metric","cnt":"9", "appid": api_key}
    if when == "today":
        response = requests.get(url_Weather_Today,params=params_Today)
        data = response.json()
        
        if data:
           
            return data['weather'][0]['description'],data['main']['temp']
        
        return None
    else:
        response = requests.get(url_Weather_Tomorrow,params=params_Tomorrow)
        data = response.json()
        if data:
            temp = data['list'][-1]['main']['temp']
            weat = data['list'][-1]['weather'][0]['description']
            
            return weat,temp
        
    
    return None
def Get_Previus_Query():
    res1 = importFromFile("last_query.txt")
    return res1[0].split(";")
def importFromFile(dir):
    file = open(dir,"r", encoding="utf-8")
    list = file.read().splitlines()
    file.close()
    return list
def saveToFile(dir,content):
    file = open(dir,"w",encoding="utf-8")
    file.write(content)
    file.close
cho = input("Use same question? (Y/N)").lower()
if cho == "n":
    city_name = input("Check weather in city: ")
    #city_name = "nysa"
    when = input("Today or Tomorrow? ")
    #when = "tomorrow"
    #print(Get_Weather(when,city_name,API_key))
    print(f" City: {city_name} \n Weather: {Get_Weather(when.lower(),city_name,API_key)[0]} \n Temparature: {Get_Weather(when.lower(),city_name,API_key)[1]}C")
    saveToFile("last_query.txt",f"{city_name};{when}")
else:
    city_name = Get_Previus_Query()[0]
    #print(city_name)
    when = Get_Previus_Query()[1]
    print(when)
    print(f" City: {city_name} \n Weather: {Get_Weather(when.lower(),city_name,API_key)[0]} \n Temparature: {Get_Weather(when.lower(),city_name,API_key)[1]}C")