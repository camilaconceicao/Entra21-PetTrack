import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent implements OnInit {
  constructor(private authService: AuthService) {}

  ngOnInit(): void {}

  enviar() {
    this.validacao();

  }

  private email = document.getElementById('validationEmail');

  validacao() {
    // Example starter JavaScript for disabling form submissions if there are invalid fields
    (() => {
      'use strict';

      // Fetch all the forms we want to apply custom Bootstrap validation styles to
      const forms = document.querySelectorAll('.needs-validation');
      
      // Loop over them and prevent submission
      Array.from(forms).forEach((form: any) => {
        form.addEventListener(
          'submit',
          (event: any) => {
            if (!form.checkValidity()) {
              event.preventDefault();
              event.stopPropagation();
            }

            form.classList.add('was-validated');
          },
          false
        );
      });
    })();


  }
}