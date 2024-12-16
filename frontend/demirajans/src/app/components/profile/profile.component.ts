import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { TokenHelperService } from '../../helpers/services/token-helper.service';
import { UserDto } from '../../services/user/models';

@Component({
  selector: 'app-profile',
  standalone: false,

  templateUrl: './profile.component.html',
  styleUrl: './profile.component.scss',
})
export class ProfileComponent implements OnInit {
  passwordVisible: boolean = false;
  userId!: number;
  userDto!: UserDto;

  get(id: number) {
    this.userService.get(id).subscribe({
      next: (n) => ((this.userDto = n), console.log(this.userDto)),
      error: (e) => console.log(e),
    });
  }

  constructor(
    private userService: UserService,
    private tokenHelperService: TokenHelperService
  ) {}

  ngOnInit(): void {
    this.userId = this.tokenHelperService.getUserIdFromToken();
    this.get(this.userId);
  }
}
