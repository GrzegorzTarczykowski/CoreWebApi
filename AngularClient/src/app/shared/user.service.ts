import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class UserService 
{
  constructor(private fb:FormBuilder, private httpClient:HttpClient) { }
  readonly BaseURL = 'https://localhost:44351/api';

  formModel = this.fb.group({
    UserName :['', Validators.required],
    Email :['', Validators.email],
    Passwords : this.fb.group({
      Password :['', [Validators.required, Validators.minLength(8)]],
      ConfirmPassword :['', Validators.required]
    }, {validators : this.comparePasswords})
  });

  comparePasswords(fb:FormGroup){
    let confirmPswrdCtrl = fb.get('ConfirmPassword')
    //passwordMismatch
    //confrimPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors)
    {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
      {
        confirmPswrdCtrl.setErrors({passwordMismatch: true});
      }
      else
      {
        confirmPswrdCtrl.setErrors(null);
      }
    }
  }

  register()
  {
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password,
    };
    return this.httpClient.post(this.BaseURL + '/IdentityUser/Register', body);
  }

  login(formData)
  {
    return this.httpClient.post(this.BaseURL + '/IdentityUser/Login', formData);
  }
}
