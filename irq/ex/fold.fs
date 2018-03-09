
\ stack operations

\ ex. 2 3 4 ['] + => 9

: fold ( stek addr -- n )			\ addr is exec: ['] ( accum n1 -- n2 )
	0 2>r									\ push accum and exec addr to ret stack
	begin depth 0<> while			\ check empty stack flag
	r> swap								\ pop and make accum 1st arg to exec
	r@ execute							\ pick exec addr, execute
	>r	repeat							\ push accum to ret stack, repeat
	2r> nip ;							\ pop accum and exec addr from ret stack

\ TODO map

\ TODO filter