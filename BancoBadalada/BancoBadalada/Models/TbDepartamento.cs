﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BancoBadalada.Models;

[Table("tb_departamentos")]
[Index("NmDepartamento", Name = "un_tb_departamentos_nm_depto", IsUnique = true)]
public partial class TbDepartamento
{
    [Key]
    [Column("id_departamento")]
    public int IdDepartamento { get; set; }

    [Column("nm_departamento")]
    [StringLength(40)]
    [Unicode(false)]
    public string NmDepartamento { get; set; } = null!;

    [Column("localizacao")]
    [StringLength(60)]
    [Unicode(false)]
    public string Localizacao { get; set; } = null!;

    [Column("id_gerente")]
    public int? IdGerente { get; set; }

    [Column("fg_ativo")]
    public bool? FgAtivo { get; set; }

    [ForeignKey("IdGerente")]
    [InverseProperty("TbDepartamentos")]
    public virtual TbEmpregado? IdGerenteNavigation { get; set; }

    [InverseProperty("IdDepartamentoNavigation")]
    public virtual ICollection<TbHistorico> TbHistoricos { get; set; } = new List<TbHistorico>();
}
