import { Component, OnInit } from '@angular/core';
import { PassengerService } from "../api/services/passenger.service";
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register-passenger',
  templateUrl: './register-passenger.component.html',
  styleUrls: ['./register-passenger.component.css']
})
export class RegisterPassengerComponent implements OnInit {

  constructor(private passengerService: PassengerService, private fb: FormBuilder,
    private authSevice: AuthService,
    private router: Router) { }

  form = this.fb.group({
    email: ['',
      Validators.compose([Validators.required, Validators.email, Validators.min(3), Validators.max(100)])
    ],
    firstName: ['',
      Validators.compose([Validators.required, Validators.min(2), Validators.max(35)])
    ],
    lastName: ['',
      Validators.compose([Validators.required, Validators.min(2), Validators.max(35)])
    ],
    isFemale: [true,
      Validators.required
    ]
  });

  ngOnInit(): void {
  }

  checkPassenger(): void {
    const params = { email: this.form.get('email')?.value };
    this.passengerService.findPassenger(params)
      .subscribe(this.login, e => {
        if (e.status !== 404)
          console.error(e);
      });
  }

  register() {
    if (this.form.invalid)
      return;

    console.log("Form Values: ", this.form.value);
    this.passengerService.registerPassenger({ body: this.form.value })
      .subscribe(this.login, console.error);
  }

  private login = () => {
    this.authSevice.loginUser({ email: this.form.get('email')?.value });
    this.router.navigate(['/search-flights']);
  }
}
