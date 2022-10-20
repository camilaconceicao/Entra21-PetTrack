import { CadastroService } from './cadastro.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent implements OnInit {
  public dados: any = {
    id: 0,
    email: '',
    senha: '',
  };

  public fieldForm = '';

  constructor(
    private authService: AuthService,
    public cadastroService: CadastroService,
    public router: Router,
    public editRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {}

  enviar() {
    this.validacao();

    this.cadastroService.salvar(this.dados).subscribe((reponse: any) => {
      this.dados.id = reponse;
    });

    this.router.navigate(['/tipo']);
  }

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

    (function () {
      'use strict';
      window.addEventListener(
        'load',
        function () {
          var forms = document.getElementsByClassName('needs-validation');
          var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener(
              'submit',
              function (event: any) {
                if (form.checkValidity() === false) {
                  event.preventDefault();
                  event.stopPropagation();
                }
                form.classList.add('was-validated');
              },
              false
            );
          });
        },
        false
      );
    })();
  }
}
