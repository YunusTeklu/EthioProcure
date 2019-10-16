using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace EthioProcure.Models
{
    public class DigitalSignature
    {
        DSACryptoServiceProvider verifier = new DSACryptoServiceProvider();

        /*private String pkBusLic = "<DSAKeyValue><P>uh6fbRcYKlV4mjjLzyfvuniF0rxp6jNq7fPAPCtpmJWpI6DbNTgIuPj8OnHJ8xv9V+Dsj26PsB1LVMZbzEk8JCy7WK3MvQg/o67EIbNKGUYqT+TSXAvOyvrSjpY3KuHXZHX84/vbnWnrN5o2wU4FdoBsdDthxlk/rAyTgwoU5fU=</P><Q>iD7j50XtQRUcYfX0N6M1hBnIktc=</Q><G>tWZ5tkKuAsAf+t7g+FOPvnIr5ckQF8e4F9MkoJMyfkmHgfFLEQel9Kj05uaI7xKpOe8S6V+sMHU69pw6JSxVN9hnVO6fQ3Dad3r6+3hSkErzGbuS5z2Khklu8Z1ZS+ZDx55z8I5OWICbGIeEe/J6dEnF863XRlxi703wA+Gsthk=</G><Y>qtVk/Xp/RAOoj5SV4jl/ece9yjXdEvsUXBJVixsJwfAX00u++6cPyyo+vGsHxEGnaF98cPy+Gq6Wez8nN7VkKk3np4IPFLMrIxnPtuInPItiqJ+ieM/PdmtMc8qtqr1hYK7GTV3Okc2zeP5sMXlFYrgHAo6Fr/PLPnlGlZdHNZ0=</Y><Seed>pJUBOvdkQS7cVl+MSYR5iA5Vzos=</Seed><PgenCounter>YQ==</PgenCounter></DSAKeyValue>";
        private String sigBusLic = "ACZIBWAJN2raOI4zQduYFAKz2l5NUPrNb3tnqlBvPEv+nw9VYs6yWA==";

        private String pkTaxClr = "<DSAKeyValue><P>zl+WK8QYB65r3NN6fQmFMDFlcMahd81sueZAG13LpmSxPK0BDYz0CHmbAsdarc2tPfnx0Hg1SYVSo3oY/jq1SRWT24c9M4DrC/12JBIoBq8GQdSx5Gwre5V91HMWeOP0QXNvNs9IaBLlmTha7JGwDCs1DOQnRnJJ2nZ/tgMq3as=</P><Q>6Ox0WPln2Uu7PaA+OSfht2b4d00=</Q><G>LH7tA1x7bFBzIpDnajNYwXqv380tCgre3Dzacl6Uxj6xvKpdGzWQdvkmqlEjyksFWNWT9mDdqGLzpx0sEVujqubflYlbr/5q1611A6Ywi7JhUlSwvLtX7zUE2Sp/TqTcz1SEFO4cKxA6qdWNVSrY+K+Y5utR0H6M9Uhx8J5hG6E=</G><Y>dr4FlMjorqi8Dzx0cXq2ucVgb/fQ8VfN7l3TRvZ0vMz0uaphiEZGDPT0reCDqpqIipmRZH/cSL5U08mO3oUab7hwYjXyGatEnrGjjqRrmgx7YDdTO4s1pLS7fEAtxd2K11x2FaOZnpuCW43KzrkjnBHjRb9DwS5xTT5kD1HahKo=</Y><Seed>+f3TY2Jnva5BVXw/3RiHFF42B0g=</Seed><PgenCounter>tg==</PgenCounter></DSAKeyValue>";
        private String sigTaxClr = "X8ZxxBD7a4f03cp2kI64kFUywUwY9HR4rcjX0K6ReRC2ZY0jU6obDQ==";

        private String pkTaxReg = "<DSAKeyValue><P>rZpNViJUx7L3wnDPiJ1PpRw/EaEzO8EOJUdIvUFKqBih2u2Oii03wVRQINNNnKeQ1jRyK+RPjBRF2C0okg1lai8vfG7VQQ9bCf7Met5O9RtMwWiVct3nKpnLsJaW72+iXlfYYf2bysiJZcHrhzBd+AdKo7qKdJUD5IJGLNga2TE=</P><Q>thZ/0l5SQupOKOJcRhG8wrFzyCE=</Q><G>lXslJzJnORzPZIcQK6bSDA808GuWU3YIClD6UN79KUNC55WLcbsO1iTWU6fMhOIJ6sii52lN5nqbikJu7ZjLf0yzWuqu0gKPRsrMhXYUGdyKc12QH6rH1xHBc9QzE8DbFEh07E58wyTRmTsouA767OgmRU+Ffkt711rlWAlD2k8=</G><Y>RfYaZdxtp/ysNeBzUjeThI4eqMs+i+proTvzT2JGEbHNLf1U1tVhYZReHjk2a9W2ef0wBmjIXnrp5mrUeZQTScTVt+zfV+KVHMvNjJIMg/H2/Kpob+/M697W3k62faZ5jowJd7GMnQJ6uJIBBes6biTZkBZbtTrw6KLNUtfrdKs=</Y><Seed>cIr7Vow+vVD/qL28F3x5xJZXJ3I=</Seed><PgenCounter>Ug==</PgenCounter></DSAKeyValue>";
        private String sigTaxReg = "CN1HrWbwCU7ZvvDfntV7bTalwDeGZeReS8r9aFg7xfajYAKrS3GRTg==";

        private String pkVatReg = "<DSAKeyValue><P>jttn7s5S6x7NSphICsMlyAwOjmw5BGEqNrjMnZ1ia1+2zjKu7hItn3ntdQvUxYwfdv6/1L6Tvy30j22j/Ra4W+LjuL4DrfWa9jYY9HrGDupUfkXJZrFxedANeYm+eXchfO9NcyE9eTEz4bss+aHhOI7OzsxkrxY01XxHuTseL98=</P><Q>oaqMNuLuV/YcSwZoz2EP42bej4U=</Q><G>JVq0o/JAUcb99CpCnd0YAjUR0G0fp6ZVUQVyTWkbkVQjAv8sFJltaKtgCxBIHcomTp7oiSlZnbXfUIMgx3UHYnkUKRXsWSNsl1iJ+SmzSRLwuTzIfA51X6WZsr/ebOauel3QKfVIfxkBQOgoHkQnsJWGXXure/rlV9zrIY9Em0I=</G><Y>McsM/YLL2xn5c+TBUspJFdlyrXZ7/4x7kO4bTG/Fht7wO4mS2CgWShibnxqVmSba6H97MIJJ7PdkD4kZQ2QyfK86bgSgqTYV1Tsq2tCHjX8hQWk5UHNVoiAsy+fnEskNfhDqwzC+ZZDSnX24MEtPV7F2kKAb5DR2aq9LtZXrDdM=</Y><Seed>PRb1QzGJfvv8LHfOzChkdrWfFD8=</Seed><PgenCounter>CQ==</PgenCounter></DSAKeyValue>";
        private String sigVatReg = "QyvdIEVhhEwx0D/2zBrSfnihrblI98BASeg6RNsuRdm/OshGt6HyoQ==";

        private String pkCoc = "<DSAKeyValue><P>87Wdik6FGU0PKGTr0dESSTe6ec7FzXm2matqCI6RRvVwgK+WNM1IZCjVeEn2EpoAPZgeDKCXhOu2oj2HhWIeuel0n7HuvPR5avbtnAbPsMaZWjK9V343fhjBhxM46KBxXzXmVGPEFOq+eOTieoSXjl9VptLOmRpX54jVRi3bO2M=</P><Q>xVbAH2ioiWy/4x81HpJpJvav0hE=</Q><G>MoggyiH4OQVvuU3Y/7yvp+ioL+M8c9F9jJRNmV8Q9LYfmrcGvnmU98jPsNQFr6xcjBxD087+lKsUVfhKZYpgkNubxjV9EEpgIf5FeEIhY1Fle1jtY24MQTek4MLPE2leUxHtZ4ASGeDUHS8R9fqoDLIcnrhUveImuHmGwSClPEk=</G><Y>wPuxuvjNRXTBZ4vAn+Y6scGCcahODHdWWpqT6wSRpRUDqVP6N/7ioyH9jA1pNHWOJzRw9oNbd8nYXY7zBhs33FRcChFWQHMudmMDiLtGYGr4caO8RQHRu9fdd4Khb0V5pf6ARjsQo0Kl9zcZHl0YPcpxWagiWq4MzSEwtgS7uYw=</Y><Seed>LhpddHudOUbsM6pbDOgdy2QsOTY=</Seed><PgenCounter>A9A=</PgenCounter></DSAKeyValue>";
        private String sigCoc = "bF3QeN6ujJMQAzwkKrBAqSWk+puOhDT4odD9G8Ft0dyy04wDV9+K6g==";

        private String pkPerLet = "<DSAKeyValue><P>975nsXZzQW4wgE6ySICSZ+BzoDmr4S5Bd8jRJ/1ab+daQB/X3m0ZIdUqeTe4x84wpUOthHxhYjDCPNQX70VJ9lBsSGOdHDJvReKYIOJhAQW0e3I1YiaN1ZQDSKrev+SZeRibtwJFS4CC48MXLDwPLg+TAzffEGPtzIWYqIgLres=</P><Q>iq0n7pDwNd1CwNGo5ln5w5y2hgs=</Q><G>YiBXbpjTb97n5xrU1fc52tsOapavzVT1Ozd8KaeNe8fKCDhqTTU0zbVD6QZb0ogRoScfH5yMgRlxUuePiQHXXz7RfGGeYUiKrAA7XCl1rLr/5U1zW8T7JqMRS8mrset4MoGQV7BFHV50dr/WrTnJG5nlXByer7MDX5ViIkI1/kI=</G><Y>0GGPzWvy8FOlku1iijHoxgyYWosPD2qKuP+oBlLz+LympWcftEyw4aNc/0zAMeJEI45H/loACd9+LVWqOzFFAGnW81xJjkVRMPrCKB+3E94Wv02E45s5m1ygDSxehaF+aqiW89CkEmUBcWISh584gxZL+SspCOQ08r6MxGJoaV8=</Y><Seed>DjDl8xH/C+4is+We8bXhi9SjtIc=</Seed><PgenCounter>AUk=</PgenCounter></DSAKeyValue>";
        private String sigPerLet = "K/u4Te8iqu6+TXmEZ01kHEE2rtCEoEobEOxMaOR8AQumGw4yLuJq+w==";

        private String pkConLic = "<DSAKeyValue><P>xkk/otvaDWNOCYXsAXr0Av/KYKqO2YOX/vMh89D3uZYI1y1SW/PNHOcbZoZOqrEhYgOOLd/QrXRiv7rVX9aYGAszXRZvJ8AZ59O7+c2GQlFCMlkTN7O3VprYQwTkQT/7BeoF72uTGS9S+3ocyUBcdiBXhCKdCi0LNLsKeSVG0IE=</P><Q>ua7aT8yCXimLvUBfsDZJkXYGP00=</Q><G>B/6g1M6e+WiGYN6OI+G/xKmUj3CLou/70gq3Vm8C2AxuKmpoOlG4J6F7H8sfNK5VSXHcmWBgPd/Zp/5C/i3qdXriNX0e7BzXqq/QCK7W4y68Qr3YbZeZoEb6N2YMfaNArIVwNtHWOYakzykn7nMVq8F606Qop38LuaFx11SESMM=</G><Y>nT5YixYzCZSKdA22GMSCQJOTfnPONkRIlGR3vmD/mxX1+TKAbtoHLhy1G7ehm4MLeOTnFS8OemihU7aA3361eqe9arkYEeaLQgKBQ3/eDbhfipkmsgK1dZ/za2ZvAoZf9GhAY6MnT/9fngQBrsgaOnJ/KEdOk6N1dsbxpSC20Yk=</Y><Seed>XmC1K8xJeGzvAOMIx+Zk+tibotU=</Seed><PgenCounter>BV0=</PgenCounter></DSAKeyValue>";
        private String sigConLic = "e1Va86Zj3hL3BeJysxfjn2hUC+cLv7Qw4voLf4Ab5V+vyguiG2EiSQ==";

        private String pkEquMach = "<DSAKeyValue><P>+eZFqriR5bLCYEayn6/HNCjNNMqkGCUaWI9jgE41+c3/Jj7dmPr+I6bA6W3Mykh9ss5Qhn7XeSw7FOjMdNdAQk6T/OYkQX2hSJsa0sl41EQycYY2WoQnVC/wgP3jTX8GELjNFWNCIXNq7DHOwRjhVp4cTp4WZ8kdCoT4GV2koAE=</P><Q>qxAkA98fPWndABkJ+bmMHtV5Hqc=</Q><G>AB4ucB54sBOKEvpGZy5pv4FXBs+RYyGBxrIUdhlML8IAsomCtcZ5jaJsTKleWblJ4sv+NmvUcpWiuDUZzAwfDHV1irO2jk6wNDaqdfSJW/lpcxM6uzvrFU0wSDzhNcXaXuLzhiK4lxOHLndSump4buTW1Bpe8rSlFxd9gNUYNMY=</G><Y>qdf5wtlpbR9T/YN2Ig0dVicONmN3XelbB3jAB3roNPStjSKMyw258Yui8eWiLgz3DY3vjpXpD1OB6bnoWc5vwsD5B8AiHE/2l08pk3CuTE+mCTGxDVtI8XRphs1g7BT5OtGHObSilRzPuL4nRxszuU2Erc28r3Q2EZY5NiH7FYI=</Y><Seed>DeOLqpA/eFdtJX0B/NwS843sr3o=</Seed><PgenCounter>QQ==</PgenCounter></DSAKeyValue>";
        private String sigEquMach = "NjzKUmbJmqPpAvVuyV++Cz3dd4QF81N6ROajfg+mMRQX39UZXWh3Zw==";

        private String pkAudRep = "<DSAKeyValue><P>5OklOZCBWk+xIdtEWOB2KRGGSPK4kB/idqcpPg234wjSwT6auaW3M8PvWKlgPzSvyziNI1d4PQUAoif+NH1G9i3ROtAlf2CIodzWEZIC6e4+ihEPAzSKwtRVhIE/5p5NHs8qrEp55NBykuGMG8zf8QtXEDqDEKlG1d4gNa5RBMk=</P><Q>p/2xLvqyIs9S0lqGc/8to4rrgpU=</Q><G>ndetICyZ8HykMnPscGZlejuDjQjqxb9EHY8f18bRX37wJTGQRMN5Fd7KsYIyIB+K+2OFDSnG3kHUjjkfyvZrJQYuu9KGn5vI2LdXPK+4xFfNKshU5C6ilDTAqm/wSAfkAj9C5vw1SFUKcqshJvJFvBaFuUIsmu2okaBkDmG1iCE=</G><Y>LYv1ePa2FQMqy3o+Dtb2xB1duQz+nLb0ED4ofRA2wX1M1LfK64G80VpYIsEYibxL4UgE3u36Ai93nyxsXwLJO3q8fDCpC8KVGUfz6XnKfT1tmbyBY5sH7jNCVqYpucxNLFKGSOF7oguPiZAkBqnS0UR8e8VEMwAXhLe36W903A4=</Y><Seed>ukSJT3iKQJwAFaXCL97K2il/OzA=</Seed><PgenCounter>AQ0=</PgenCounter></DSAKeyValue>";
        private String sigAudRep = "MQMkEvwXXslFavEUF2aStqJkOMwhxMFvyBKG6+kcKmtDAJaoZ/MPQg==";

        private String pkProPraCer = "<DSAKeyValue><P>/VL7FqKCec8CmJdwZwYzm4VuLmCabpQwyJSCbeLVlfCXs980HVmd0MhYzkI3b3Wf5UsRrQlMtImKSTj0w5t+zIn+mF8LcjSh85mPwE0MYI2/xBCrv4spebIOKIMpyOwF4yr/LMllrZ/GN9NVBBSZERXcJQoa0f9/MyRGFDEI1mE=</P><Q>qHfhvQcRwSzx5IzhJezFKbSX//E=</Q><G>C+7OxFWK/n7u+yF4Dmw2O88xsFibAwYge89r8iPmPfXwz7ZikU8nGDFa0sqEtuIGVq8v7was7XBoEtmJ0Hs+UL+a3z7k8xX0cWlR8EWFWynQ9Q0vrNdM4B9fDeDnkcJNnGTuMkqlfIE+/YDKDKIuPBsSGnJJKml9a3jUBkSchlA=</G><Y>LIazrigUIKR0yLnN0ekIvHrSxsTZFkMkFMlAM7dTCFHcV8NrhdJwPql1AGD7EmtlC02VNJWyJy4u+YE0Lsu5cZmXGpG3eocYuqZJQNhkPXjFXFSIOvzuL9a210lggqaQfPUHykOuXsqfwjFviLepVZkZ91LYkOzwT189VI59REg=</Y><Seed>7I4O29mRhcUKfcboDcI53B+GEi0=</Seed><PgenCounter>Cw==</PgenCounter></DSAKeyValue>";
        private String sigProPraCer = "cTF8GDI6uoCJL/83LmX06cLtNv5lw7/mpi9n3OJjQVYBN+MvPNnNvw==";

        private String pkFppa = "<DSAKeyValue><P>2+VVOpU80dTT2k0+NV6tYim+hSqbvEp3XHdFLtLuTwyBPo+IZ4hRd1CaD0yLZknMO9lt+b1offzH5R7DNFqitWnUze/Jre1OADwt1pUF7F9oq+cZzIjKCrgBNcUcfQWK/lxUvIuYpJmo50qPfa2Nij4qB6JjT6Ts1orYn9D0dm0=</P><Q>9U0bWKil8K52mI4D8CnsdFP9B2E=</Q><G>yHW1NztG8DeZj3Bw1VnaWxzdhfjtqzMuGV1oThtpQDGP1IjCNLKwk6YO+8Bq7bjRqRexBNEKa3cebNVx6dOn0P2cmt3Hbv2+f5PuZ8eGo7agAq9NQw+Z4IbSGZD/Rn8xBYwfDJJ4hO88HqYWGwqWeN8mFNukv1z3GU6taDOxFOE=</G><Y>UoWDkdGKHI1GSx3wybN2jw3dOD42shoT/kDkIyKrMhN9TQioaPQm+Zmw/jXLfi4KEdUqIq9pRW2RldWII2Fn34tqfyiiYmT0KxbWyTidTroPgpE2UwDCb0AfG3gE+gj1QMsUO2WReq31ocIFlwOEcwIErT0/MelWyVpFqx24UX8=</Y><Seed>5c2KKuSJS3ABrmZ7iG7T/+9EFoA=</Seed><PgenCounter>gQ==</PgenCounter></DSAKeyValue>";
        private String sigFppa = "6bnM9E6tYYqm6u5srh53wHse6lpMp7qaX3pLcNxA7ghDb9K4ZTM3Xg==";
        */
        private String pkPbCert = "<DSAKeyValue><P>wakNn9GW2p1luk6mzO8XMwvR89zF/hBHcSN2y7ZMPIzLsaXwWyOAsWvm8jITrEBT33uo/TmitUSc44bDrGZUnF5oUKKP/P/W4rPtQCWAnQHHwlbbOHXs3DKgyUsS701vqIB8vFtgibZW87EhzSA8Cn6WNuVTK3sqLQ31WpLz5qM=</P><Q>zNHZOENgpk95Eh46gj4VwiLWuKM=</Q><G>lRpuIXo+NHJ58JRBrtXkjhpDxhX+lDZsDhqCxusCxDwtK5Xk6MMPA6KT7AWrrkM+i6DdtbbA8XLo/u7wAsYyzTZARq7z6qjal/eVAlDnrAoW0m7k5B4HmUor0k2+qXzjPlDcm45A1G4nz2ab9hPwACbZ8zvKRrzXjqmQUFt5cEA=</G><Y>k4cdW+npzUmfnRRqSpWxUoYOrk2qOXZF/D7xD55xRc3j7TLYKb5IEVX6gCieYNSp3Tbet3GKC2wNjv+OLrFyh9+U8N9JcPOAczD11IDblr6H3cXbz498hTdO2UOeNb8HNRey+aWIygVidr8ypu69gAZPNp+QgCB8MmVZ0CnVzG0=</Y><Seed>0bkarg40nRgr59Fu4lgpOn7AqeQ=</Seed><PgenCounter>OA==</PgenCounter></DSAKeyValue>";
        //private String sigPbCert = "h8XIqx3hoXAcwN+eZucPXSr191SRkUhUH6UymGAbIpJZFJX4bn/R6A==";

        public bool verifyPbCert(byte[] data, String sign)
        {
            byte[] signature= Convert.FromBase64String(sign);
            verifier.FromXmlString(pkPbCert);

            if (verifier.VerifyData(data, signature))
                return (true);
            else
                return (false);
        }
    }
}