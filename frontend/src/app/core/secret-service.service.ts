import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecretServiceService {
  apiKey: string = "7bc821d41d5911bbb9a5c243b762a3a8";
  constructor() {
  }

  getApiKey(): string {
    return this.apiKey;
  }
}
