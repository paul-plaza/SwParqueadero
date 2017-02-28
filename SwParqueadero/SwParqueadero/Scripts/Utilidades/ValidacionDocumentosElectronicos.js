

        function funValidarDocumento(ddlTipoIdentificacion,txtNumeroIdentificacion) {
            var terminacionRUCN = '001';
            var terminacionRUCE = '0001';
            var valor = true;
            var suma = 0;
            var residuo = 0;
            var privada = false;
            var publica = false;
            var natural = false;
            var numeroProvincias = 24;
            var digitoVerificador = 0;
            var modulo = 11;
            var numero;

            var opcion = ddlTipoIdentificacion.value;
            numero = txtNumeroIdentificacion.value;

            var d1, d2, d3, d4, d5, d6, d7, d8, d9, d10;
            var p1, p2, p3, p4, p5, p6, p7, p8, p9;

            d1 = d2 = d3 = d4 = d5 = d6 = d7 = d8 = d9 = d10 = 0;
            p1 = p2 = p3 = p4 = p5 = p6 = p7 = p8 = p9 = 0;
            if (numero != "") {
                ///*************************************************************************************************
                if (opcion == 1) {
                    var tamanoId = numero.length;
                    if (tamanoId < 10) {


                        valor = false;
                    }
                    // Los primeros dos digitos corresponden al codigo de la provincia
                    if (numero.length > 3) {
                        var provincia = numero.substring(0, 2);

                        if (provincia <= 0 || provincia > numeroProvincias) {

                            valor = false;

                        }
                    }
                    // Aqui almacenamos los digitos de la cedula en variables.
                    d1 = numero.substring(0, 1);
                    d2 = numero.substring(1, 2);
                    d3 = numero.substring(2, 3);
                    d4 = numero.substring(3, 4);
                    d5 = numero.substring(4, 5);
                    d6 = numero.substring(5, 6);
                    d7 = numero.substring(6, 7);
                    d8 = numero.substring(7, 8);
                    d9 = numero.substring(8, 9);
                    d10 = numero.substring(9, 10);

                    // El tercer digito es:
                    // 9 para sociedades privadas y extranjeros
                    // 6 para sociedades publicas
                    // menor que 6 (0,1,2,3,4,5) para personas naturales
                    if (d3 == 7 || d3 == 8) {

                        valor = false;

                    }

                    // Solo para personas naturales (modulo 10)
                    if (d3 < 6) {
                        natural = true;
                        modulo = 10;
                        p1 = d1 * 2;
                        if (p1 >= 10)
                            p1 -= 9;
                        p2 = d2 * 1;
                        if (p2 >= 10)
                            p2 -= 9;
                        p3 = d3 * 2;
                        if (p3 >= 10)
                            p3 -= 9;
                        p4 = d4 * 1;
                        if (p4 >= 10)
                            p4 -= 9;
                        p5 = d5 * 2;
                        if (p5 >= 10)
                            p5 -= 9;
                        p6 = d6 * 1;
                        if (p6 >= 10)
                            p6 -= 9;
                        p7 = d7 * 2;
                        if (p7 >= 10)
                            p7 -= 9;
                        p8 = d8 * 1;
                        if (p8 >= 10)
                            p8 -= 9;
                        p9 = d9 * 2;
                        if (p9 >= 10)
                            p9 -= 9;
                    }

                    // Solo para sociedades publicas (modulo 11)
                    // Aqui el digito verficador esta en la posicion 9, en las otras 2
                    // en la pos. 10
                    if (d3 == 6) {
                        publica = true;
                        p1 = d1 * 3;
                        p2 = d2 * 2;
                        p3 = d3 * 7;
                        p4 = d4 * 6;
                        p5 = d5 * 5;
                        p6 = d6 * 4;
                        p7 = d7 * 3;
                        p8 = d8 * 2;
                        p9 = 0;
                    }

                    /* Solo para entidades privadas (modulo 11) */
                    if (d3 == 9) {
                        privada = true;
                        p1 = d1 * 4;
                        p2 = d2 * 3;
                        p3 = d3 * 2;
                        p4 = d4 * 7;
                        p5 = d5 * 6;
                        p6 = d6 * 5;
                        p7 = d7 * 4;
                        p8 = d8 * 3;
                        p9 = d9 * 2;
                    }

                    suma = p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9;
                    residuo = suma % modulo;

                    // Si residuo=0, dig.ver.=0, caso contrario 10 - residuo
                    digitoVerificador = residuo == 0 ? 0 : modulo - residuo;
                    var longitud = numero.length; // Longitud del string

                    // ahora comparamos el elemento de la posicion 10 con el dig. ver.
                    if (longitud >= 10) {

                        if (publica == true) {
                            if (digitoVerificador != d9) {

                                valor = false;

                            }
                            /* El ruc de las empresas del sector publico terminan con 0001 */
                            if (numero.substring(9, longitud) != terminacionRUCE) {

                                valor = false;

                            }
                        }

                        if (privada == true) {
                            if (digitoVerificador != d10) {

                                valor = false;

                            }
                            if (numero.substring(10, longitud) != terminacionRUCN) {

                                valor = false;

                            }
                        }

                        if (natural == true) {
                            if (digitoVerificador != d10) {

                                valor = false;

                            }

                            var tam = numero.length;
                            if (tam > 10
						&& numero.substring(10, longitud) != terminacionRUCN) {

                                valor = false;

                            }
                        }
                    }

                }
            }
            //***********************************************************************


            //****************************************************************
            if (opcion == 2) {
                var tamanoId = numero.length;
                if (tamanoId < 13) {


                    valor = false;
                } else {
                    // Los primeros dos digitos corresponden al codigo de la provincia
                    if (numero.length > 3) {
                        var provincia = numero.substring(0, 2);

                        if (provincia <= 0 || provincia > numeroProvincias) {

                            valor = false;

                        }
                    }
                    // Aqui almacenamos los digitos de la cedula en variables.
                    d1 = numero.substring(0, 1);
                    d2 = numero.substring(1, 2);
                    d3 = numero.substring(2, 3);
                    d4 = numero.substring(3, 4);
                    d5 = numero.substring(4, 5);
                    d6 = numero.substring(5, 6);
                    d7 = numero.substring(6, 7);
                    d8 = numero.substring(7, 8);
                    d9 = numero.substring(8, 9);
                    d10 = numero.substring(9, 10);

                    // El tercer digito es:
                    // 9 para sociedades privadas y extranjeros
                    // 6 para sociedades publicas
                    // menor que 6 (0,1,2,3,4,5) para personas naturales
                    if (d3 == 7 || d3 == 8) {

                        valor = false;

                    }

                    // Solo para personas naturales (modulo 10)
                    if (d3 < 6) {
                        natural = true;
                        modulo = 10;
                        p1 = d1 * 2;
                        if (p1 >= 10)
                            p1 -= 9;
                        p2 = d2 * 1;
                        if (p2 >= 10)
                            p2 -= 9;
                        p3 = d3 * 2;
                        if (p3 >= 10)
                            p3 -= 9;
                        p4 = d4 * 1;
                        if (p4 >= 10)
                            p4 -= 9;
                        p5 = d5 * 2;
                        if (p5 >= 10)
                            p5 -= 9;
                        p6 = d6 * 1;
                        if (p6 >= 10)
                            p6 -= 9;
                        p7 = d7 * 2;
                        if (p7 >= 10)
                            p7 -= 9;
                        p8 = d8 * 1;
                        if (p8 >= 10)
                            p8 -= 9;
                        p9 = d9 * 2;
                        if (p9 >= 10)
                            p9 -= 9;
                    }

                    // Solo para sociedades publicas (modulo 11)
                    // Aqui el digito verficador esta en la posicion 9, en las otras 2
                    // en la pos. 10
                    if (d3 == 6) {
                        publica = true;
                        p1 = d1 * 3;
                        p2 = d2 * 2;
                        p3 = d3 * 7;
                        p4 = d4 * 6;
                        p5 = d5 * 5;
                        p6 = d6 * 4;
                        p7 = d7 * 3;
                        p8 = d8 * 2;
                        p9 = 0;
                    }

                    /* Solo para entidades privadas (modulo 11) */
                    if (d3 == 9) {
                        privada = true;
                        p1 = d1 * 4;
                        p2 = d2 * 3;
                        p3 = d3 * 2;
                        p4 = d4 * 7;
                        p5 = d5 * 6;
                        p6 = d6 * 5;
                        p7 = d7 * 4;
                        p8 = d8 * 3;
                        p9 = d9 * 2;
                    }

                    suma = p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9;
                    residuo = suma % modulo;

                    // Si residuo=0, dig.ver.=0, caso contrario 10 - residuo
                    digitoVerificador = residuo == 0 ? 0 : modulo - residuo;
                    var longitud = numero.length; // Longitud del string

                    // ahora comparamos el elemento de la posicion 10 con el dig. ver.
                    if (longitud >= 10) {
                        //************************************************************
                        if (publica == true) {
                            if (digitoVerificador != d9) {

                                valor = false;

                            }
                            /* El ruc de las empresas del sector publico terminan con 0001 */
                            if (numero.substring(9, longitud) != terminacionRUCE) {

                                valor = false;

                            }
                        }
                        //**********************************************
                        if (privada == true) {
                            if (digitoVerificador != d10) {

                                valor = false;

                            }
                            if (numero.substring(10, longitud) != terminacionRUCN) {

                                valor = false;

                            }
                        }
                        //*****************************************************
                        if (natural == true) {
                            if (digitoVerificador != d10) {

                                valor = false;

                            }

                            var tam = numero.length;
                            if (tam > 10
						&& numero.substring(10, longitud) != terminacionRUCN) {

                                valor = false;

                            }
                        }
                        //**********************************************************

                    }

                }

            }

            //****************************************************************
            if (valor == false) {
                alert('Numero de Identificacion Incorrecto');
              txtNumeroIdentificacion.value = "";
                
                ddlTipoIdentificacion.focus()
            } else {  }

        }



        /****************************************************
        * Descripcion: Funcion que valida Enteros
        *  Febrero-2014
        *****************************************************/
        function funValidaEntero() {
            if ((window.event.keyCode > 0 && window.event.keyCode < 48) || (window.event.keyCode > 57 && window.event.keyCode < 255))
                window.event.returnValue = false;
            else
                window.event.returnValue = true;
        }
        /****************************************************
        * Descripcion: Funcion que valida Letras
        *  Diciembre 2015
        *****************************************************/

        function funSoloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " abcdefghijklmnopqrstuvwxyz ";
           
            if (letras.indexOf(tecla) == -1)
                return false;
        }
        function limpia(txtvalor) {

            var val = txtvalor.value;
            var tam = val.length;
            for (i = 0; i < tam; i++) {
                if (!isNaN(val[i]))
                    txtvalor.value = '';
            }
        }
        function funInicio() {
           ddlTipoIdentificacion.focus()

        }
        /*******************************************************************************************
        * Descripcion: Funcion que valida el Campo Identificacion de acuerdo al Tipo de Documento
        * Diciembre 2015
        *********************************************************************************************/
        function funValidarIngresoDocumentos(e,ddlTipoIdentificacion) {
            var opcion = ddlTipoIdentificacion.value;
            if (opcion == 3) {
                key = e.keyCode || e.which;
                tecla = String.fromCharCode(key).toLowerCase();
                letras = " abcdefghijklmnopqrstuvwxyz1234567890_";
                especiales = [8, 45, 46];

                tecla_especial = false
                for (var i in especiales) {
                    if (key == especiales[i]) {
                        tecla_especial = true;
                        break;
                    }
                }

                if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                    return false;
                }
            } else {
                funValidaEntero();
            }
        }
        /****************************************************
        * Descripcion: Funcion que Convierte a Mayusculas
        *  Febrero - 2014
        *****************************************************/
        function Mayusculas(txt) {
            var texto = trim(txt.value.toString());
            texto = texto.toUpperCase();
            txt.value = texto;
        }
        function onTecla(e, btnAceptar) {
            var num = e ? e.keyCode : event.keyCode;

            if (parseInt(num) == 18 || parseInt(num) == 17) {
                btnAceptar.focus();
            }


        }
         function onTecla(e) {
            var num = e ? e.keyCode : event.keyCode;

            if (parseInt(num) == 18 || parseInt(num) == 17) {
                alert('No se admiten caracteres especiales');
            }


        }

        /****************************************************
        * Descripcion: Funcion que valida Letras Direcciones
        *  Diciembre 2015
        *****************************************************/

        function funSoloLetrasRazon(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " abcdefghijklmnopqrstuvwxyz1234567890_ ";
            especiales = [8, 39, 46];

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial)
                return false;
        }

        /****************************************************
        * Descripcion: Funcion que valida Letras Direcciones
        *  Diciembre 2015
        *****************************************************/

        function funSoloLetrasDireccion(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " abcdefghijklmnopqrstuvwxyz1234567890_ ";
            especiales = [8, 39, 46];

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial)
                return false;
        }

        /****************************************************
        * Descripcion: Funcion que valida Letras Mail
        *  Diciembre 2015
        *****************************************************/

        function funSoloLetrasDireccionMail(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = "abcdefghijklmnopqrstuvwxyz1234567890_@.-";
         

            if (letras.indexOf(tecla) == -1)
                return false;
        }

          /****************************************************
        * Descripcion: Funcion que valida Entero
        *  Diciembre 2015
        *****************************************************/
         function funSoloNumeros(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = "0123456789";
            if (letras.indexOf(tecla) == -1)
                return false;
        }
        
       /****************************************************
        * Descripcion: Funcion que valida Entrada Fechas
        *  Diciembre 2015
        *****************************************************/
         function funFechasEntrada(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = "0123456789/";
            if (letras.indexOf(tecla) == -1)
                return false;
        }

      
       
       
        /****************************************************
        * Descripcion: Funcion que limita el Tamanio
        *  Diciembre 2015
        *****************************************************/
            function limitaTamanio(maximoCaracteres, elemento) 
        {
            if (elemento.value.length >= maximoCaracteres) {
                elemento.value='' ;
            }
        
        }
        /****************************************************
        * Descripcion: Funcion Valida celular
        *  Diciembre 2015
        *****************************************************/
        function validaCel(txt) {
            var cel = document.getElementById(txt);
            var exp = /^09\d{8}/;
            if (cel.value != "") {

                if (!exp.test(cel.value)) {
                    cel.value = '';
                alert("Formato del Campo celular Incorrecto Ejm: 0912345678") 
            }
            }

        }
        /****************************************************
        * Descripcion: Funcion Valida mail
        *  Diciembre 2015
        *****************************************************/
        function validaMail(txt) {
            
            var valor = document.getElementById(txt); 
            var exp = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.([a-zA-Z]{2,4})+$/;
            if(valor.value!=""){
            if (!exp.test(valor.value)) {
                valor.value = '';
                alert("Formato del Campo mail Incorrecto ejm usuario@dominio.com, usuario@dominio.com.ec ");
            }

            }

    }

    /****************************************************
    * Descripcion: Funcion Valida Telefono
    *  Diciembre 2015
    *****************************************************/
    function validaTelefono(txt) {
        var tel = document.getElementById(txt.id);
        exp = /^\d{7}/;
        if (tel.value != "") {
            
                if (!exp.test(tel.value)) {
                    alert("Formato del Campo Telefono Incorrecto ejm 2123456 ");
                    tel.value = '';                
            }
        }

    }
    /***************************************
    *Codigo de Area
    ******************************************/
    function validaCodigoArea(txt) {
        var area = document.getElementById(txt.id);
        var exp = /^0\d{1}/;

        if (area.value != "") {

            if (!exp.test(area.value)) {
                alert("Formato del Campo Codigo Area Incorrecto ejm 02 ");
                area.value = '';
            }

        }

    }
      /***************************************
    *Codigo de Pais
    ******************************************/
      function validaCodigoPais(txt) {
        var exp = /d{3}/;

        if (txt.value != "") {

            if (!exp.test(txt.value)) {
                txt.value = '';
                alert("Formato del Campo Codigo de Pais Incorrecto ejm 593 ");
            }

        }

    }

      
        
        /****************************************************
        * Descripcion: Funcion limita tamanio minimo campos
        *  Diciembre 2015
        *****************************************************/
        function funtamMinimoCampo(txt, num, nom) {
            if (txt.value != "") {
                if (txt.value.length < num) {
                    alert("El campo " + nom + " no tiene el minimo requrido de caracteres que es " + num);
                    txt.value = "";
                }
            }
        }
/*****************************************************
*Funcion para Validar Decimales 2
*
******************************************************/


function funValidaDecimal(txtValor) 
{
	if ((window.event.keyCode > 0 && window.event.keyCode < 48 && window.event.keyCode != 46) || (window.event.keyCode > 57 && window.event.keyCode < 255 ))
		window.event.returnValue = false;
    else
    {
		if (window.event.keyCode==46)
		{
			if (txtValor.value.indexOf(".")< 0) 
			{
				if (txtValor.value.length==0)
				{
					txtValor.value = "0";
						
				}
				
					window.event.returnValue=true;		
			}
			else
				window.event.returnValue=false;
		}
		else
		{
			if (txtValor.value.indexOf(".")>=0)
			{
				if (txtValor.value.substring(txtValor.value.indexOf("."),txtValor.value.length).length>2)
					window.event.returnValue=false;
				else
					window.event.returnValue=true;
			}
			else
				window.event.returnValue=true;		
		}
	}
}
/*************************************
*Mascara para fechas
**************************************/
//valida formato yyyy/mm/dd aspirante
function IsNumeric(valor)
{
	var log=valor.length;
	var sw="S";
	for (x=0; x<log; x++)
	{
	   v1=valor.substr(x,1);
	   v2 = parseInt(v1);
		//Compruebo si es un valor numérico
		if (isNaN(v2))
		{
		sw= "N";
		}
	}
	
	if (sw=="S")
	{return true;}
	else
	{return false;}
	}

	var primerslap=false;
	var segundoslap=false;
function formateafecha(fecha)
{
	var longitud = fecha.length;
	var dia;
	var mes;
	var ano;

	   ano=fecha.substr(0,4);
	   if ((longitud>=4) && (primerslap==false))
	   {
		   
		   ano=fecha.substr(0,4);
		  
		   if ((IsNumeric(ano)== false) || ((ano==0) || (ano<1900) || (ano>2500)))
		   {
		       fecha=""; primerslap=false;
		   }
		   else
		   {
		      fecha=fecha.substr(0,4)+"/"+fecha.substr(5,9); primerslap=true;
		   }
	    }
		else
		{
		    ano=fecha.substr(0,4);
		    if (IsNumeric(ano)==false)
		    {
		        fecha="";
		     }
		     if ((longitud<=4) && (primerslap=true))
		     {
		        fecha=fecha.substr(0,4); primerslap=false;
		     }
	   }
	    
	   
	   if ((longitud>=7) && (segundoslap==false))
	   {
		   mes=fecha.substr(5,2);
		   if ((IsNumeric(mes)==true) &&(mes<=12) && (mes!="00"))
		   {
		       fecha=fecha.substr(0,7)+"/"+fecha.substr(8,2); segundoslap=true;
		   }
		   else
		   {
		      fecha=fecha.substr(0,5);; segundoslap=false;
		   }
	    }
	   else
		{
		     if ((longitud<=7) && (segundoslap=true))
		    {
		       fecha=fecha.substr(0,6); segundoslap=false;
		    }
	   }
	   
	   if (longitud>=9)
       {
           dia=fecha.substr(8,5);
           if (IsNumeric(dia)==false)
           {
               fecha=fecha.substr(0,8);
           }
           else
           {
               if (longitud==10)
               {
				   if ((dia >31) || (dia=="00"))
                  {
                      fecha=fecha.substr(0,8);
                   }
				  
                }
           }
     } 
	 	 

    return (fecha);
}

/*************************************
*
*Validador de Fechas
*
***********************************/

function esFechaValidaI(txtFechaDesde){
    if (txtFechaDesde.value != "" ){
    var fecha=txtFechaDesde.value;
  fecha=fecha.replace(/-/g,'/');
  var expreg = /^([0-9]{4})\/([0-9]{2})\/([0-9]{2})$/;
        if (!expreg.test(fecha)){
        alert("Ingrese una Fecha Valida");
       txtFechaDesde.value="";
            return false;
        }
  var anio =  parseInt(fecha.substring(0,4));   
  var dia  =  fecha.substring(8,10); 
        var mes  =  fecha.substring(5,7);
   if(mes>0 && mes<=12){
    switch(mes){
        case "01":
        case "03":
        case "05":
        case "07":
        case "08":
        case "10":
        case "12":
            numDias=31;
            break;
        case "04": 

        case "06": 

        case "09": 

        case "11":
            numDias=30;
            break;
        case "02":
            if (comprobarSiBisiesto(anio)){ numDias=29 }else{ numDias=28};
            break;
        default:
            return false;
    }
 
        if (dia>numDias || dia==0){
              alert("Ingrese una Fecha Valida");
			txtFechaDesde.value="";
            return false;
        }
        }else{
           alert("Ingrese una Fecha Valida");
			txtFechaDesde.value="";
        return false;
        }
        
        return true;
    }
}
 
function comprobarSiBisiesto(anio){
if ( ( anio % 100 != 0) && ((anio % 4 == 0) || (anio % 400 == 0))) {
    return true;
    }
else {
    return false;
    }
}
