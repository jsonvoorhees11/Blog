import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  constructor(private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) {
    this.form = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      username: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  login() {
    const formValue = this.form.value;
    if (formValue.email && formValue.password) {
      this.authService.login(formValue.email,formValue.username, formValue.password)
        .subscribe((res: boolean) => {
          if (res) {
            console.log("Authorize succesfully!");
            this.router.navigateByUrl('/admin');
          }
        })
    }
  }

}
