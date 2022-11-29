import { AbstractControl } from '@angular/forms';

export function ValidateDataAniversario(control: AbstractControl) {
  let dataAtual = new Date();
  let dataAniversario = new Date(control.value);
  
  if (dataAniversario > dataAtual ) {
    return { invalidData: true };
  }

  return null;
}

export function ValidateSenha(control: AbstractControl) {
  let senha: string = control.value.toString();

  if (!/[0-9]/.test(senha)) {
    return { invalidSenha: true ,Motivo:"É necessário pelo menos um digito númerico!"};
  }
  else if(!/[a-z]/.test(senha)){
    return { invalidSenha: true ,Motivo:"É necessário pelo menos uma letra minúscula!"};
  }
  else if(!/[A-Z]/.test(senha)){
    return { invalidSenha: true ,Motivo:"É necessário pelo menos uma letra maiúscula!"};
  }
  else if(senha.length < 8){
    return { invalidSenha: true ,Motivo:"Senha deve possuir no mínimo 8 digitos!"};
  }

  return null;
}