import { Guid } from "guid-typescript";

export interface IForecast {

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

export interface IFriendRelationship {
    username: string,
    friendname: string
}

export interface IPlant {
    id: string,
    name: string,
    growth_minuets: number,
    worth: number,
    image_path: string,
    state: number,
}

export interface ITile {
    id: string,
    garden_id: string,
    position: string,
    plant_information: IPlant,
    plant_time: any, //this may need to be a number
    ground_time: any
}

export interface IGarden {
    id: string,
    user_id: string,
    tiles: ITile[]
}

export interface IPlants {
    id: string,
    name: string,
    growth_minutes: number;
    worth: number
}

export interface IPost {
    id: string,
    sender_id: string,
    reciver_id: string,
    text: string,
    time: any,
    sender_name: string
}

export interface IAuthResult {
    token: string,
    expires: Date
}

export interface ICoordinates{
    zip: number,
    name: string,
    lat: number,
    lon: number,
    country: string
}
