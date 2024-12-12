import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SpinningBarService {
  private readonly loading$ = new Subject<boolean>();

  loading(value: boolean): void {
    this.loading$.next(value);
  }

  loadingChanges(): Observable<boolean> {
    return this.loading$.asObservable();
  }
}
