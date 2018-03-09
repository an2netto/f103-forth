GPIO-BASE $0800 + constant GPIOC

$0000 constant PORTA
$0400 constant PORTB
$0800 constant PORTC

: equal? ( n n -- flag ) \ 
	= if 0 else -1 then ;

: flag. ( flag -- ) \ print flag
	if cr ." false" else cr ." true" then ;

: example1 ( -- flag)
	gpioc pa3 io-base equal? ;

: example2 ( -- flag)
	gpioc pc13 io-base equal? ;

example1 flag.
example2 flag.

: unpin ( pin -- port# pin# )
	dup $FF and swap					\ pin
	$F00 and 2 lshift					\ port
	case 
		PORTA of 1 endof
	 	PORTB of 2 endof
	 	PORTC of 3 endof
		drop cr ." Unknown port"
	endcase ;



