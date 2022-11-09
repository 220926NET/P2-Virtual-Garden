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

export interface ITile {
    id: Guid,
    garden_id: Guid,
    position: string,
    plant_id: Guid,
    plant_time: any, //this may need to be a number
    ground_time: any
}

export interface IGarden {
    id: string,
    user_id: string,
    tiles: ITile[]
}

export interface IPlants {
    id: Guid,
    name: string,
    growth_minutes: number;
    worth: number
}

export interface IPost {
    id: Guid,
    sender_id: Guid,
    receiver_id: Guid,
    text: string,
    time: any,
    sender_name: string
}

