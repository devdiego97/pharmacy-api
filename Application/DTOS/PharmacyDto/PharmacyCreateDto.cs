using System.ComponentModel.DataAnnotations;

namespace Application.DTOS.PharmacyDto
{
    /// <summary>
    /// DTO para criação de uma nova farmácia
    /// </summary>
    public record PharmacyCreateDto
  (
	/// <summary>
	/// ID do administrador responsável pela farmácia (deve ser um GUID válido de um usuário existente)
	/// </summary>
	[Required(ErrorMessage = "O ID do administrador é obrigatório")]
	Guid idAdmin,
	
	[Required(ErrorMessage = "O nome é obrigatório")]
    string Name,
	
	[Required(ErrorMessage = "O CNPJ é obrigatório")]
	string Cnpj,
	
	[Required(ErrorMessage = "A cidade é obrigatória")]
	string City,
	
	[Required(ErrorMessage = "O estado é obrigatório")]
	string State,
	
	[Required(ErrorMessage = "O endereço é obrigatório")]
	string Address,
	
	string? LogoUrl,
	
	[Required(ErrorMessage = "O telefone é obrigatório")]
	string Phone,
	
	[Required(ErrorMessage = "O email é obrigatório")]
	[EmailAddress(ErrorMessage = "Email inválido")]
	string Email,
	
	[Required(ErrorMessage = "A senha é obrigatória")]
	string PassHash
  );
}