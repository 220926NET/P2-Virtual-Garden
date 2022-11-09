import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecretServiceService {
  apiKey: string = "Get your own lol";
  constructor() {
  }

  getApiKey(): string {
    return this.apiKey;
  }
}
