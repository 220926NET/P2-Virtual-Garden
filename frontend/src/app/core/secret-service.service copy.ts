import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecretServiceService {
    apiKey : string = "your API Key goes here";
  constructor() {
   }

  getApiKey():string{
    return this.apiKey;
  }
}
