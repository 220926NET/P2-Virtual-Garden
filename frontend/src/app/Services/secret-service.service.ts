import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecretServiceService {
    apiKey : string = "4528e6e6fa6c759c6930d98771fb8251";
  constructor() {
   }

  getApiKey():string{
    return this.apiKey;
  }
}
