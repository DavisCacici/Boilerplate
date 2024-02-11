using Microsoft.AspNetCore.Identity;
using Server.Data;

namespace Server.Seeds;

public static class SeedRuoliEUtenti 
{ 
    public async static Task Seed( 
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager, 
            string utente, string email, 
            string ruolo) 
    { 
            await CreaRuolo(roleManager, ruolo); 
            await AssegnaRuoloAdUtente(userManager, utente, email, ruolo); 
    } 
      
    private async static Task CreaRuolo( 
            RoleManager<IdentityRole> roleManager, string ruolo) 
    { 
            bool esisteRuolo = 
                await roleManager.RoleExistsAsync(ruolo); 
            if(!esisteRuolo) 
            { 
                var role = new IdentityRole 
                { 
                    Name = ruolo 
                }; 
                await roleManager.CreateAsync(role); 
            } 
    } 
 
    private async static Task AssegnaRuoloAdUtente( 
            UserManager<ApplicationUser> userManager, 
            string utente, string email, string ruolo) 
    { 
            bool esisteUtente = await userManager.FindByEmailAsync(utente) != null; 
            if(esisteUtente == false) 
            { 
                var nuovoUtente = new ApplicationUser 
                { 
                    UserName = utente, 
                    Email = email,
                }; 
                var result = await userManager.CreateAsync(nuovoUtente, "MiaPassword1!"); 
 
                if(result.Succeeded == true) 
                { 
                    await userManager.AddToRoleAsync(nuovoUtente, 
                                       ruolo); 
                } 
           }  
    } 
} 
