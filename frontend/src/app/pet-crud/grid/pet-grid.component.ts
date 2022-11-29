import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataGridComponent } from 'src/components/data-grid/data-grid.component';
import { GridService } from 'src/components/data-grid/data-grid.service';
import { EnumBase } from 'src/enums/EnumBase';
import { TypeFilter } from 'src/enums/TypeFilter';
import { GridOptions } from 'src/objects/Grid/GridOptions';

@Component({
  selector: 'pet-grid-component',
  templateUrl: './pet-grid.component.html',
  styleUrls: ['./pet-grid.component.css']
})
export class PetGridComponent {
  gridOptions: GridOptions;
  optionsEnumPerfil: Array<EnumBase>;
  
  constructor(private gridService: GridService,public gridComponent: DataGridComponent,
    private router: Router){  
    this.optionsEnumPerfil = [
      {
        Description: 'Administrador',
        Value: '0'
      },
      {
        Description: 'Comum',
        Value: '1'
      }
    ];

    this.gridOptions = {
        Parametros: {
          Controller: 'Usuario',
          Metodo: 'ConsultarGridUsuario',
          PaginatorSizeOptions: [10,15,20],
          PageSize: 10,
          MultiModal: true,
          Modal: undefined,
          Params: {
            Teste: 1
          }
        },
        Colunas: [{
            Field: 'Action',
            DisplayName: 'Ações',
            CellTemplate: undefined,
            Type: TypeFilter.none,
            Filter: false,
            OrderBy: false,
            EnumName: undefined,
            ServerField: '',
            EnumOptions: undefined,  
            StyleColuna: undefined,  
            StyleCell: undefined,
            ClassCell: undefined,
            CellGraphics: undefined,
            CellImage: undefined,
            ActionButton: [
              {
                TypeActionButton: 0,
                TypeButton: 1,
                ParametrosAction: {
                  Conteudo: '<i class="bi bi-pencil-square"></i>',
                  ClassProperty: 'btn btn-info btn-sm',
                  Disabled: {
                    Disabled: undefined,
                    PropertyDisabled: ''
                  },
                  Hidden: {
                    Hidden: false,
                    PropertyHidden: ''
                  },
                  Target: undefined,
                  Href: undefined,
                  Tooltip: 'Editar'
                }
              }
            ]  
        },
        {
          Field: 'idPet',
          DisplayName: 'Cód do pet',
          CellTemplate: undefined,
          ActionButton: undefined,
          Type: TypeFilter.Number,
          EnumName: undefined,
          Filter: true,
          OrderBy: true,
          ServerField: 'IdPet',
          StyleColuna: undefined,
          EnumOptions: undefined,
          StyleCell: undefined,
          ClassCell: undefined,   
          CellGraphics: undefined,
          CellImage: undefined,
        },
        {
          Field: 'nome',
          DisplayName: 'Nome',
          CellTemplate: undefined,
          ActionButton: undefined,
          Type: TypeFilter.String,
          EnumName: undefined,
          OrderBy: true,
          Filter: true,
          ServerField: 'Nome',
          StyleColuna: 'min-width: 40vh; max-width: 50vh;',
          EnumOptions: undefined,
          StyleCell: 'margin-left:5pt; padding: 2pt; border-radius: 2pt; background: rgb(40,167,69);',
          ClassCell: 'd-inline text-white',
          CellGraphics: undefined,
          CellImage: {
            PropertyLink: 'imagemUsuario',
            ClassImage: 'rounded float-start d-inline',
            StyleImage: 'max-width: 30pt;',
            Tooltip:  'Foto do usuário',
            OnlyImage: false
          },    
        },
        {
          Field: 'idade',
          DisplayName: 'Idade',
          CellTemplate: undefined,
          ActionButton: undefined,
          Type: TypeFilter.Number,
          EnumName: undefined,
          ServerField: 'idade',
          Filter: true,
          OrderBy: true,
          StyleColuna: 'width: 100pt;',
          EnumOptions: undefined,
          StyleCell: 'width: 100pt;',
          ClassCell: undefined,
          CellGraphics: undefined,
          CellImage: undefined,    
        },
        {
          Field: 'tipoCadastro',
          DisplayName: 'Perfil do pet',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.Enum,
          EnumName: undefined,
          ServerField: 'perfil',
          Filter: true,
          OrderBy: true,
          StyleColuna: 'width:10vh',
          EnumOptions: this.optionsEnumPerfil,
          StyleCell: undefined,
          ClassCell: undefined,
          CellGraphics: undefined,
          CellImage: undefined,  
        }
      ]
    }
  }

  Editar(data: any){
    this.router.navigate(['main/usuario/' + data.idUsuario.toString() + '/editar']);
  }
}
