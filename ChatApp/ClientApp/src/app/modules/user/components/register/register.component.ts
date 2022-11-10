import { Component } from '@angular/core';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent {
   
  public User: User = {
    Username: '',
    Email: '',
    Password: ''
  }

  onRegister = () => {
     
  }
}
