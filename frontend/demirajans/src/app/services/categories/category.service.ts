import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProxyService } from '../proxy/proxy.service';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private baseUrl = "Category";

  constructor(private proxyService: ProxyService) {}

  getlist(): Observable<any> {
    return this.proxyService.get<any>(this.baseUrl + "/list");
  }
}
