import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/shared/user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
  formModel={
    UserName: '',
    Password: ''
  }
  constructor(private userService:UserService, private router:Router, private toastrService:ToastrService) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') != null)
    {
      this.router.navigate(['/home']);
    }
  }

  onSubmit(form:NgForm){
    this.userService.login(form.value).subscribe(
      (res:any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
      },
      err => {
        if(err.status == 400)
        {
          this.toastrService.error('Incorrect username or password.','Authentication failed')
        }
        else
        {
          console.log(err);
        }
      }
    );
  }
}
