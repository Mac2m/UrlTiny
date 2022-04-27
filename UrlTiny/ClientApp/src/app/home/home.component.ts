import {Component, ElementRef, Inject, ViewChild} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ShortUrlDto} from "../fetch-data/short-url.dto";
import {ServiceResponse} from "../fetch-data/service-response";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  @ViewChild('shortUrlInput', {read: ElementRef, static: false}) shortUrlInputElement: ElementRef;
  spanText: string;
  shortUrl: ShortUrlDto;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }

  onSubmit() {
    const shortUrlInput = this.shortUrlInputElement.nativeElement.value;
    const url = environment.apiUrl + 'home';
    this.http.post<ServiceResponse<ShortUrlDto>>(url, { longUrl: shortUrlInput }).subscribe(result => {
      this.spanText = result.data.shortUrl;
    }, error => console.error(error));
  }

  }

  interface shortUrlRequestModel {
    longUrl: string;
  }
