using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BancoBadalada.Models;

[Table("tb_empregados")]
public partial class TbEmpregado
{
    [Key]
    [Column("id_empregado")]
    public int IdEmpregado { get; set; }

    [Column("nm_empregado")]
    [StringLength(60)]
    [Unicode(false)]
    public string NmEmpregado { get; set; } = null!;

    [Column("iniciais_empregado")]
    [StringLength(5)]
    [Unicode(false)]
    public string IniciaisEmpregado { get; set; } = null!;

    [Column("ds_cargo")]
    [StringLength(40)]
    [Unicode(false)]
    public string? DsCargo { get; set; }

    [Column("id_gerente")]
    public int? IdGerente { get; set; }

    [Column("dt_nascimento", TypeName = "date")]
    public DateTime DtNascimento { get; set; }

    [Column("salario", TypeName = "numeric(7, 2)")]
    public decimal Salario { get; set; }

    [Column("comissao")]
    public double? Comissao { get; set; }

    [Column("id_departamento")]
    public int? IdDepartamento { get; set; }

    [Column("fg_ativo")]
    public bool? FgAtivo { get; set; }

    [ForeignKey("IdGerente")]
    [InverseProperty("InverseIdGerenteNavigation")]
    public virtual TbEmpregado? IdGerenteNavigation { get; set; }

    [InverseProperty("IdGerenteNavigation")]
    public virtual ICollection<TbEmpregado> InverseIdGerenteNavigation { get; set; } = new List<TbEmpregado>();

    [InverseProperty("IdInstrutorNavigation")]
    public virtual ICollection<TbCursosOferecidos> TbCursosOferecidos { get; set; } = new List<TbCursosOferecidos>();

    [InverseProperty("IdGerenteNavigation")]
    public virtual ICollection<TbDepartamento> TbDepartamentos { get; set; } = new List<TbDepartamento>();

    [InverseProperty("IdEmpregadoNavigation")]
    public virtual ICollection<TbHistorico> TbHistoricos { get; set; } = new List<TbHistorico>();

    [InverseProperty("IdParticipanteNavigation")]
    public virtual ICollection<TbMatricula> TbMatriculas { get; set; } = new List<TbMatricula>();
}
