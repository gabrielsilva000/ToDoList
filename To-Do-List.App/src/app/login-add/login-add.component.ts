import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Login } from '../models/login.model';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-add',
  standalone: false,
  templateUrl: './login-add.component.html',
  styleUrl: './login-add.component.css'
})
export class LoginAddComponent implements OnInit{
  form!: FormGroup;

  constructor(private loginService: LoginService,
              private router: Router) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      id: new FormControl(0),
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      dateCreation: new FormControl(new Date())
    });
  }

  submit(){
    const login: Login = {
      id: this.form.value.id,
      username: this.form.value.username,
      password: this.form.value.password,
      dateCreation: this.form.value.dateCreation,
    };
    this.loginService.RegisterLogin(login).subscribe(data => {
      this.router.navigate(['/']);
    });
  }

}
