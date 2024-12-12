import { Component, Input, OnInit, Renderer2, ViewChild } from '@angular/core';
import { SpinningBarService } from '../../../helpers/services/spinning-bar.service';

@Component({
  selector: 'app-spinning-bar',
  standalone: false,

  templateUrl: './spinning-bar.component.html',
  styleUrl: './spinning-bar.component.scss',
})
export class SpinningBarComponent implements OnInit {
  @Input() loading: boolean = false;

  constructor(
    private spinningBarService: SpinningBarService,
    private renderer: Renderer2
  ) {}

  ngOnInit(): void {
    this.spinningBarService.loadingChanges().subscribe((loading) => {
      this.loading = loading;
      if (loading) this.renderer.addClass(document.body, 'disabled');
      else this.renderer.removeClass(document.body, 'disabled');
    });
  }
}
