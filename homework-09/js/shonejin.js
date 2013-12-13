// Shone JIN.js
// Deals with functions related to algorithm showing


var mode = 1;           // mode(1,2,3,4) representes normal, h, v, hv
var radom = true;       // generate radom value
var isRunning = false;
var dimension_x;
var dimension_y;
var dimension_y2;
var input = new Array(); // input array, from auto gen or file
var inputR = new Array();// reversed input array, for mode v
var PS = new Array();   // partial sum, used in algorithm
var step_end = 1;       // the last step we have
var step_cur = 0;       // the step to show
var step = new Array();
var sum = new Array();  // sum of sub array of each step
var timmer;
var speed=600;          // auto moving step speed
var isAuto = 0; 

// run when "Let's go" button clicked
function Load()
{
	isRunning=true;
	step_end = 1;
	step_cur = 1;
	SetMode();
	GetInput();
	InitialGrid();
	Core();
	AutoMove();
}

// set mode to a, h, v, hv. represented by 1 2 3 4
function SetMode()
{
	var modeOpRadio2 = document.getElementById("optionsRadios2");
	var modeOpRadio3 = document.getElementById("optionsRadios3");
	var modeOpRadio4 = document.getElementById("optionsRadios4");
	if(modeOpRadio2.checked == true)
		mode = 2;
	if(modeOpRadio3.checked == true)
		mode = 3;
	if(modeOpRadio4.checked == true)
		mode = 4;
}

// if input is a file, read file to input array; or read dimension 
function GetInput()
{
	if(radom)
	{
		dimension_y2=dimension_x = dimension_y = $("#inpt1").val();
		for(var k = 0; k <= dimension_x ; k++)
		{
		    // generate double dimension
			inputR[k]=new Array();
			PS[k] = new Array();
		}
		for(var k = 1; k <= dimension_x ; k++)
		{      
			input[k]=new Array();
			for(var j = 1;j <= dimension_y; j++)
			{   
		  		input[k][j]=Math.round(Math.random()*200 - 100);
		  		inputR[j][k] = input[k][j];
		 	}
		}
	}
	else
	{
        // get file path
		readFile($("#inpt2").val());
	}
}

// read file from path "filename"
function readFile(filename)
{    
	var fso = new ActiveXObject("Scripting.FileSystemObject");     
	var f = fso.OpenTextFile(filename, true);    
	var s = "";     
	while (!f.AtEndOfStream)     
		s += f.ReadLine()+"\n";     
	f.Close();     
	alert(s);    
}   

// show the data table
// assign id attribute and value to each cell
function InitialGrid()
{
	var a = 1;	
    var tbd,row,cell;
    var tbl=document.getElementById("showtable");
    var p=tbl.parentNode;
    p.removeChild(tbl);
    tbl=document.createElement("table");
    tbl.setAttribute("class","table-bordered");
    tbl.setAttribute("id","showtable");
    p.appendChild(tbl);
    tbd=document.createElement("tbody");
    tbl.appendChild(tbd);
    for (var i=1;i <= dimension_y;++i) {
        row=document.createElement("tr");
        row.setAttribute("align","center");
        row.setAttribute("height","40px");
        for (var j=1;j<= dimension_x;++j) {
            cell=document.createElement("td");
            row.appendChild(cell);
            cell.innerHTML=input[j][i];
            cell.setAttribute("contenteditable","false");
            cell.setAttribute("id", a++);
        }
        tbd.appendChild(row);
    }
}

// run on radio button clicked
// disable input boxes by radio buttons
function SetInputActive(m)
{
	if(m == true)
	{
		$("#inpt1").removeAttr("disabled");
		$("#inpt2").attr("disabled", "disabled");
		radom = true;

	}
	else
	{
		$("#inpt1").attr("disabled", "disabled");
		$("#inpt2").removeAttr("disabled");
		radom = false;
	}
}

// change mode: auto or not
// start or stop timmer
function AutoMove()
{
	if(isAuto == 1)
	{
		clearInterval(timmer);
		isAuto = 0;
	}
	else
	{
		timmer=setInterval(ShowOneStep,speed);
		isAuto = 1;
	}
}

// run on "<" button clicked
// set back current step
function MovePrev()
{
	if(!isRunning || step_cur <= 1)
		return;
	step_cur-= 2;
	ShowOneStep();
}

function MoveNext()
{
	if(!isRunning)
		return;
	ShowOneStep();
}

// find "sum" showing panel and update its value
// n: current selected sum of sub array
function setSum(n)
{
	var SumPane = document.getElementById("sum");
	SumPane.innerHTML = n;
}

// work as main function of calculating max sub array
function Core()
{
	switch(mode)
	{
		case 1://normal
			sum[0] = MaxSum_mode1(0);
			break;
		case 2://h
			sum[0] = MaxSum_mode2(0);
			break;
		case 3://v
			sum[0] = MaxSum_mode3();
			break;
		case 4://hv
			sum[0] = MaxSum_mode4();
			break;
	}
}

// assistant function
function cal_PS(){
	var i, j;
	for (i = 0; i <= dimension_y; i++){
		PS[i][0] = 0;
	}
	for (j = 0; j <= dimension_x; j++){
		PS[0][j] = 0;
	}
	for (i = 1; i <= dimension_x; i++){
		for (j = 1; j <= dimension_y; j++){
			PS[i][j] = PS[i - 1][j] + PS[i][j - 1] - PS[i - 1][j - 1] + input[i][j];
		}
	}
}

// assistant function
function BC(a, c, i){
	NewStep(a, c, i);
	return PS[c][i] - PS[a - 1][i] - PS[c][i - 1] + PS[a - 1][i - 1];
}

// mode normal
// isCalled == 1 means it is reused by other mode
function MaxSum_mode1(isCalled)
{
	if(isCalled == 0){
		cal_PS();
	}
	var maximum = -2147483648;
	var Start, All;
	for (var a = 1; a <= dimension_y; a++){
		for (var c = a; c <= dimension_y; c++){
			Start = BC(a, c, dimension_x);
			All = Start;
			sum[step_end++] = All;
		    // when a new item add to end of the array,
            //      the new max sub array remains the same, or ended with the new item
			for (var i = dimension_x - 1; i >= 1; i--){
				if(Start < 0)
					Start = 0;
				Start += BC(a, c, i);
				if(Start > All)
					All = Start;
				sum[step_end++] = All;
			}
			if(All > maximum)
				maximum = All;
		}
	}
	return maximum;
}

// mode h
// isCalled == 1 means it is reused by other mode
function MaxSum_mode2(isCalled)
{
	if(isCalled == 0){
		cal_PS();
	}

    // in this mode, max array have two kinds:
    //      same with normal mode, or with two ends
	var MaxSum_noJump = MaxSum_mode1(1);
	var MaxSum_Jump;
	
	var minimum = 2147483647;// a very small value
	var Start, All;
	var WholeSum = 0;
	var tmpSum = 0;
	for (var a = 1; a <= dimension_x; a++){
		for (var c = a; c <= dimension_y; c++){
			tmpSum = 0;
			Start = BC(a, c, dimension_x - 1);
			All = Start;
			sum[step_end++] = All;
            // find the min inner-array, so that the left part have max value
			for (var i = dimension_x - 2; i > 1; i--){
				if(Start > 0)
					Start = 0;
				Start += BC(a, c, i);
				if(Start < All)
					All = Start;
				tmpSum += BC(a, c, i);
				sum[step_end++] = All;
			}
			if(All <= minimum){
				var newSum = tmpSum + BC(a, c, 1) + BC(a, c, dimension_x) + BC(a, c, dimension_x - 1);
				if (newSum - All > WholeSum - minimum){
					minimum = All;
					WholeSum = newSum;
				}
			}
		}
	}
	MaxSum_Jump = WholeSum - minimum;
	return MaxSum_noJump > MaxSum_Jump ? MaxSum_noJump : MaxSum_Jump;
}

// use reversed input and use mode h
// and the v mode is solved
function MaxSum_mode3(){
	readArrayR();
	cal_PS();
	return MaxSum_mode2(1);
}

// reversed input[][] to 90 degree
function readArrayR()
{
	for (var i = 1; i <= dimension_x; i++)
	{
		for (var j = 1; j <= dimension_y; j++)
		{
			input[i][j] = inputR[i][j];
		}
	}
}

// make some preperations
// A[], or input[] can be calculated efficiently using PS[] in Dynamic Algorithm
function makeA(a, c)
{
	var i, j;
	for (i = 1; i < a; i++){
		for (j = 1; j <= dimension_x; j++){
			input[i][j] = inputR[i][j];
		}
	}
	var iA = i;
	for (i = c + 1; i <= dimension_y2; i++){
		for (j = 1; j <= dimension_x; j++){
			input[i - c + a - 1][j] = inputR[i][j];
		}
	}
	dimension_y = dimension_y2 - (c - a + 1);
	cal_PS();
}

function MaxSum_mode4()
{ 
	cal_PS();
	var Max_md1 = MaxSum_mode1(1);
	var Max_md2 = MaxSum_mode2(1);
	var Max_md3 = MaxSum_mode3();
	var Max_md4;
	Max_md4 = -2147483648;
	var a, c;
	var tmp = Max_md4;
	for (a = 2; a < dimension_y2; a++){
		for (c = a; c < dimension_y2; c++){
			makeA(a, c);
			tmp = MaxSum_mode2(1);
			if (tmp > Max_md4){
				Max_md4 = tmp;
			}
		}
	}
    // chose max from four modes
	if(Max_md1 > Max_md4)
		Max_md4 = Max_md1;
	if(Max_md2 > Max_md4)
		Max_md4 = Max_md2;
	if(Max_md3 > Max_md4)
		Max_md4 = Max_md3;
	return Max_md4;
}

// set cell with id to a color
function setGridBg(id, color)
{
	var cell = document.getElementById(id);
	if (color == 1) {
		cell.setAttribute("bgcolor", "lightgreen");
	}
	else
		cell.setAttribute("bgcolor", "transparent");
}

// make a new space to hold new step selected cells
function NewStep(a, c, i)
{
	step[step_end] = new Array();
	for (var k = 1; k <= dimension_x * dimension_y2; k++) {
		if(k >= (a - 1)*dimension_x + 1 && k <= (c-1) * dimension_x + parseInt(i))
		{
			step[step_end][k] = 1;
		}
		else
		{
			step[step_end][k] = 0;
		}
		
	};
}

// mark selected cells in a step
// update the current sub sum
function ShowOneStep()
{
	if(!isRunning)
	{
		return;
	}
	step_cur++;
	if (step_cur >= step_end) 
	{
		setSum(sum[0]);
		alert("All Steps Completed!");
		isRunning = 0;
		return;
	};
	for (var i = 1; i <= dimension_x * dimension_y2; i++) {
		setGridBg(i, step[step_cur][i]);
	};
	setSum(sum[step_cur]);
}

// this function is not used currently
// it finds out the result subarray,
//      this program just shows the mid-step, not include selected ones.
function MakeFinalStep(x1, x2, y1, y2)
{
	step[0] = new Array();
	for (var i = 1; i <= dimension_x * dimension_y1; i++) {
		if(i >= dimension_x * (y1 - 1) + x1 && i <= dimension_x * (y2 - 1) + x2)
			step[step_end][i] = 1;
		else
			step[step_end][i] = 0;
	};
}