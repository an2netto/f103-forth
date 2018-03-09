
: led-on ( -- )
	pc13 ioc! ;

: led-off ( -- )
	pc13 ios! ;

: gpio-init ( -- )
	omode-pp pc13 io-mode! ;		\ set mode to output, push-pull

gpio-init
led-on