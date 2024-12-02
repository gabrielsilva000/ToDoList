import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  form!: FormGroup;
  authError: string | null = null;

  constructor(private fb: FormBuilder,
              private authService: AuthService)
              { }

  get f(): any {return this.form.controls;}

  ngOnInit() {
    this.form = this.fb.group({
      username:  ['', Validators.required],
      password: ['',  Validators.required]
    });
  }

  login(): void {
    const username = this.form.get('username')?.value;
    const password = this.form.get('password')?.value;

    this.authService.login(username, password).subscribe(
      () => {
        console.log('Login realizado com sucesso');
      },
      error => {
        this.authError = "Login incorreto!";
      }
    );
  }

}
