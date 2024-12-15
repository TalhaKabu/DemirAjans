import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  standalone: false,

  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit {
  passwordVisible: boolean = false;

  ngOnInit(): void {}
}
