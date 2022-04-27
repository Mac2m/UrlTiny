import {Component, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ShortUrlDto} from "./short-url.dto";
import {ServiceResponse} from "./service-response";
import {environment} from "../../environments/environment";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public urls: ShortUrlDto[];

  constructor(http: HttpClient) {
    const url = environment.apiUrl + 'home';
    http.get<ServiceResponse<ShortUrlDto[]>>(url).subscribe(result => {
      this.urls = result.data;
    }, error => console.error(error));
  }
}

