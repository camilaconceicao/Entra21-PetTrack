import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataGridComponent } from 'src/components/data-grid/data-grid.component';
import { GridService } from 'src/components/data-grid/data-grid.service';
import { EnumBase } from 'src/enums/EnumBase';
import { TypeFilter } from 'src/enums/TypeFilter';
import { GridOptions } from 'src/objects/Grid/GridOptions';
import { RetornoPadrao } from 'src/objects/RetornoPadrao';
import { BaseService } from 'src/service/base-service.component';

@Component({
  selector: 'pet-grid-component',
  templateUrl: './pet-grid.component.html',
  styleUrls: ['./pet-grid.component.css']
})
export class PetGridComponent {
  gridOptions: GridOptions;
  optionsEnumPerfil: Array<EnumBase>;
  loading: boolean = false;
  
  constructor(private response: BaseService,private gridService: GridService,
    private toastr: ToastrService,private router: Router){  
    this.optionsEnumPerfil = [
      {
        Description: 'Doação',
        Value: '0'
      },
      {
        Description: 'Perdido',
        Value: '1'
      }
    ];

    this.gridOptions = {
        Parametros: {
          Controller: 'Pet',
          Metodo: 'ConsultarGridPet',
          PaginatorSizeOptions: [5,10],
          PageSize: 5,
          MultiModal: false,
          Modal: undefined,
          Params: undefined
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
                  Conteudo: 'edit',
                  ClassProperty: 'Basic',
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
              },
              {
                TypeActionButton: 2,
                TypeButton: 1,
                ParametrosAction: {
                  Conteudo: 'delete_forever',
                  ClassProperty: 'warn',
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
                  Tooltip: 'Deletar'
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
          StyleColuna: 'min-width: 10vh; max-width: 20vh;',
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
          StyleColuna: 'min-width: 40vh; max-width: 50vh; font-size: 10pt;',
          EnumOptions: undefined,
          StyleCell: 'margin-left:10pt; padding: 5pt; border-radius: 2pt; background: rgb(40,167,69);',
          ClassCell: 'd-inline text-white',
          CellGraphics: undefined,
          CellImage: {
            PropertyLink: 'fotoBase64',
            ClassImage: 'rounded float-start d-inline',
            StyleImage: 'max-width: 80pt; border-radius: 20pt; border: 4pt double rgb(180, 180, 180)',
            Tooltip:  'Foto do pet',
            OnlyImage: false
          },    
        },
        {
          Field: 'local',
          DisplayName: 'Local',
          CellTemplate: undefined,
          ActionButton: undefined,
          Type: TypeFilter.String,
          EnumName: undefined,
          ServerField: 'local',
          Filter: false,
          OrderBy: false,
          StyleColuna: 'width: 30vh;',
          EnumOptions: undefined,
          StyleCell: 'width: 30vh;',
          ClassCell: undefined,
          CellGraphics: undefined,
          CellImage: undefined,    
        },
        {
          Field: 'tipoCadastro',
          DisplayName: 'Tipo do cadastro',
          CellTemplate: undefined,
          ActionButton: undefined, 
          Type: TypeFilter.Enum,
          EnumName: undefined,
          ServerField: 'tipoCadastro',
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
    this.router.navigate(['editar-pet/' + data.idPet.toString()]);
  }

  Deletar(data: any){
    this.loading = true;

    this.response.Post("Pet","DeleteById?id=" + data.idPet,undefined).subscribe(
      (response: RetornoPadrao) =>{        
        if(response.sucesso){
          this.toastr.success(response.mensagem, 'Mensagem:');
          this.gridService.RecarregarGrid();
        }
        else{
          this.toastr.error(response.mensagem, 'Mensagem:');
        }
        this.loading = false;
      }
    );
  }
}
