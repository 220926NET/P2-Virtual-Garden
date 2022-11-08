export interface IForecast{

    coord: {
        lon: number,
        lat: number
    },
    weather: [
        {
            id: number,
            //This or description are mainly what we are after
            main: string,
            description: string,
            icon: string
        }
    ],
    base: string,
    main: {
        temp: number,
        feels_like: number,
        temp_min: number,
        temp_max: number,
        pressure: number,
        humidity: number
    },
    visibility: number,
    wind: {
        speed: number,
        deg: number
    },
    clouds: {
        all: number
    },
    dt: number,
    sys: {
        type: number,
        id: number,
        country: string,
        sunrise: number,
        sunset: number
    },
    timezone: number,
    id: number,
    name: string,
    cod: number
    
}

export interface ITile{
    id: string,
    gardenId: number,
    position: string,
    plantId: string,
    plantTime: any, //this may need to be a number
    groundTime: any
}

export interface IGarden{
    id: string,
    userId: string,
    tiles: ITile[]
}

export interface IPlants{
    id:string,
    name: string,
    growthMinutes: number;
    worth: number
}

export interface IPost{
    id:string,
    senderId?: string,
    receiverId?: string,
    text: string,
    time: any,
    sender_name: string
}

