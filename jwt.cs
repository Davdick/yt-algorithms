//// FIRST INSTALL
/// Microsoft.AspNetCore.Authentication.JwtBearer

////////////////////////        PROGRAM      ////////////
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "yourdomain.com",
            ValidAudience = "yourdomain.com",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("esta_es_una_clave_secreta_muy_segura_123"))
        };
    });
builder.Services.AddAuthorization();
app.UseAuthentication();
app.UseAuthorization();

//////////////////////     API      ////////////////////////
 private string GenerateJwtToken(string username)
 {
     var claims = new[]
     {
     new Claim(JwtRegisteredClaimNames.Sub, username),
     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
 };

     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("esta_es_una_clave_secreta_muy_segura_123"));
     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

     var token = new JwtSecurityToken(
         issuer: "yourdomain.com",
         audience: "yourdomain.com",
         claims: claims,
         expires: DateTime.Now.AddMinutes(30),
         signingCredentials: creds);

     return new JwtSecurityTokenHandler().WriteToken(token);
 }

 [HttpPost("login")]
public IActionResult Login([FromBody] loginDto user)
{
    if (user.Username == "admin" && user.Password == "password")
    {
        var token = GenerateJwtToken(user.Username);
        return Ok(new { token });
    }
    return Unauthorized();
}