import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from 'src/app/core/models/register.model';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  validationErrors?: any;

  constructor(
    private authService: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadRegisterForm();
  }

  loadRegisterForm(): void {
    this.registerForm = this.fb.group({
      userName: ['', [Validators.required]],
      displayName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  register(): void {
    const user: Register = {
      userName: this.registerForm.value['userName'],
      displayName: this.registerForm.value['displayName'],
      email: this.registerForm.value['email'],
      password: this.registerForm.value['password'],
    };

    this.authService.register(user).subscribe({
      error: (error: any) => {
        this.validationErrors = error;
        console.log(this.validationErrors);
      },
    });
  }

  cancel(): void {
    this.router.navigate(['']);
  }

  get userNameFormControl(): FormControl {
    return this.registerForm.get('userName') as FormControl;
  }

  get displayNameFormControl(): FormControl {
    return this.registerForm.get('displayName') as FormControl;
  }

  get emailFormControl(): FormControl {
    return this.registerForm.get('email') as FormControl;
  }

  get passwordFormControl(): FormControl {
    return this.registerForm.get('password') as FormControl;
  }
}
