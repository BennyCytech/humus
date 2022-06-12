using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace humus.Models
{
    public class _SQL
    {
  #region XXX
  public string Getorder = @"
                              select * from [order]
                          ";

  public string Neworder = @"
                              INSERT INTO[dbo].[order]
                              (    
                                [name]
                                ,[phone]
                                ,[address]
                                ,[fkPaymentMethod]
                                ,[remarks]
                                ,[sum10]
                                ,[sum9]
                                ,[sum8]
                                ,[sum7]
                                ,[sum6]
                                ,[sum5]
                                ,[sum4]
                                ,[sum3]
                                ,[sum2]
                                ,[sum1]
                                ,[OrderCount]
                                ,[OrderSum]
                                ,[humusKilo]
                                ,[fullKilo]
                                ,[kilo18]
                                ,[kilo19]
                                ,[kilo20]
                                ,[kilo21]
                                ,[kilo17]
                                ,[kilo16]
                                ,[kilo15]
                                ,[kilo14]
                                ,[kilo13]
                                ,[kilo12]
                                ,[kilo11]
                                ,[kilo10]
                                ,[kilo9]
                                ,[kilo8]
                                ,[kilo7]
                                ,[kilo6]
                                ,[kilo5]
                                ,[kilo4]
                                ,[kilo3]
                                ,[kilo2]
                                ,[kilo1]
                                ,[check110]
                                ,[check19]
                                ,[check18]
                                ,[check17]
                                ,[check16]
                                ,[check15]
                                ,[check14]
                                ,[check13]
                                ,[check12]
                                ,[check11]
                                ,[check210]
                                ,[check29]
                                ,[check28]
                                ,[check27]
                                ,[check26]
                                ,[check25]
                                ,[check24]
                                ,[check23]
                                ,[check22]
                                ,[check21]
                                ,[check310]
                                ,[check39]
                                ,[check38]
                                ,[check37]
                                ,[check36]
                                ,[check35]
                                ,[check34]
                                ,[check33]
                                ,[check32]
                                ,[check31]
                                ,[check410]
                                ,[check49]
                                ,[check48]
                                ,[check47]
                                ,[check46]
                                ,[check45]
                                ,[check44]
                                ,[check43]
                                ,[check42]
                                ,[check41]
                                ,[check510]
                                ,[check59]
                                ,[check58]
                                ,[check57]
                                ,[check56]
                                ,[check55]
                                ,[check54]
                                ,[check53]
                                ,[check52]
                                ,[check51]
                                ,[check610]
                                ,[check69]
                                ,[check68]
                                ,[check67]
                                ,[check66]
                                ,[check65]
                                ,[check64]
                                ,[check63]
                                ,[check62]
                                ,[check61]
                                ,[name6]
                                ,[name5]
                                ,[name4]
                                ,[name3]
                                ,[name2]
                                ,[name1]
                                ,[KiloCount]
                                ,[KiloSum18]
                                ,[KiloSum19]
                                ,[KiloSum20]
                                ,[KiloSum21]
                                ,[KiloSum17]
                                ,[KiloSum16]
                                ,[KiloSum15]
                                ,[KiloSum14]
                                ,[KiloSum13]
                                ,[KiloSum12]
                                ,[KiloSum11]
                                ,[KiloSum10]
                                ,[KiloSum9]
                                ,[KiloSum8]
                                ,[KiloSum7]
                                ,[KiloSum6]
                                ,[KiloSum5]
                                ,[KiloSum4]
                                ,[KiloSum3]
                                ,[KiloSum2]
                                ,[KiloSum1]
                                ,[email]
                                ,[d]
                              )
                          VALUES
                              (
                                @name
                                ,@phone
                                ,@address
                                ,@fkPaymentMethod
                                ,@remarks
                                ,@sum10
                                ,@sum9
                                ,@sum8
                                ,@sum7
                                ,@sum6
                                ,@sum5
                                ,@sum4
                                ,@sum3
                                ,@sum2
                                ,@sum1
                                ,@OrderCount
                                ,@OrderSum
                                ,@humusKilo
                                ,@fullKilo
                                ,@kilo18
                                ,@kilo19
                                ,@kilo20
                                ,@kilo21
                                ,@kilo17
                                ,@kilo16
                                ,@kilo15
                                ,@kilo14
                                ,@kilo13
                                ,@kilo12
                                ,@kilo11
                                ,@kilo10
                                ,@kilo9
                                ,@kilo8
                                ,@kilo7
                                ,@kilo6
                                ,@kilo5
                                ,@kilo4
                                ,@kilo3
                                ,@kilo2
                                ,@kilo1
                                ,@check110
                                ,@check19
                                ,@check18
                                ,@check17
                                ,@check16
                                ,@check15
                                ,@check14
                                ,@check13
                                ,@check12
                                ,@check11
                                ,@check210
                                ,@check29
                                ,@check28
                                ,@check27
                                ,@check26
                                ,@check25
                                ,@check24
                                ,@check23
                                ,@check22
                                ,@check21
                                ,@check310
                                ,@check39
                                ,@check38
                                ,@check37
                                ,@check36
                                ,@check35
                                ,@check34
                                ,@check33
                                ,@check32
                                ,@check31
                                ,@check410
                                ,@check49
                                ,@check48
                                ,@check47
                                ,@check46
                                ,@check45
                                ,@check44
                                ,@check43
                                ,@check42
                                ,@check41
                                ,@check510
                                ,@check59
                                ,@check58
                                ,@check57
                                ,@check56
                                ,@check55
                                ,@check54
                                ,@check53
                                ,@check52
                                ,@check51
                                ,@check610
                                ,@check69
                                ,@check68
                                ,@check67
                                ,@check66
                                ,@check65
                                ,@check64
                                ,@check63
                                ,@check62
                                ,@check61
                                ,@name6
                                ,@name5
                                ,@name4
                                ,@name3
                                ,@name2
                                ,@name1
                                ,@KiloCount
                                ,@KiloSum18
                                ,@KiloSum19
                                ,@KiloSum20
                                ,@KiloSum21
                                ,@KiloSum17
                                ,@KiloSum16
                                ,@KiloSum15
                                ,@KiloSum14
                                ,@KiloSum13
                                ,@KiloSum12
                                ,@KiloSum11
                                ,@KiloSum10
                                ,@KiloSum9
                                ,@KiloSum8
                                ,@KiloSum7
                                ,@KiloSum6
                                ,@KiloSum5
                                ,@KiloSum4
                                ,@KiloSum3
                                ,@KiloSum2
                                ,@KiloSum1
                                ,@email
                                ,GETDATE()
                              ) ";

  public string Updateorder = @"UPDATE [dbo].[order]
                                  SET
                                    [name] = @name
                                    ,[phone] = @phone
                                    ,[address] = @address
                                    ,[fkPaymentMethod] = @fkPaymentMethod
                                    ,[remarks] = @remarks
                                    ,[o10] = @o10
                                    ,[o9] = @o9
                                    ,[o8] = @o8
                                    ,[o7] = @o7
                                    ,[o6] = @o6
                                    ,[o5] = @o5
                                    ,[o4] = @o4
                                    ,[o3] = @o3
                                    ,[o2] = @o2
                                    ,[o1] = @o1
                                    ,[fkMana10] = @fkMana10
                                    ,[fkMana9] = @fkMana9
                                    ,[fkMana8] = @fkMana8
                                    ,[fkMana7] = @fkMana7
                                    ,[fkMana6] = @fkMana6
                                    ,[fkMana5] = @fkMana5
                                    ,[fkMana4] = @fkMana4
                                    ,[fkMana3] = @fkMana3
                                    ,[fkMana2] = @fkMana2
                                    ,[fkMana1] = @fkMana1
                                    ,[thina10] = @thina10
                                    ,[gargirim10] = @gargirim10
                                    ,[egg10] = @egg10
                                    ,[eggplant10] = @eggplant10
                                    ,[thina9] = @thina9
                                    ,[gargirim9] = @gargirim9
                                    ,[egg9] = @egg9
                                    ,[eggplant9] = @eggplant9
                                    ,[thina8] = @thina8
                                    ,[gargirim8] = @gargirim8
                                    ,[egg8] = @egg8
                                    ,[eggplant8] = @eggplant8
                                    ,[thina7] = @thina7
                                    ,[gargirim7] = @gargirim7
                                    ,[egg7] = @egg7
                                    ,[eggplant7] = @eggplant7
                                    ,[thina6] = @thina6
                                    ,[gargirim6] = @gargirim6
                                    ,[egg6] = @egg6
                                    ,[eggplant6] = @eggplant6
                                    ,[thina5] = @thina5
                                    ,[gargirim5] = @gargirim5
                                    ,[egg5] = @egg5
                                    ,[eggplant5] = @eggplant5
                                    ,[thina4] = @thina4
                                    ,[gargirim4] = @gargirim4
                                    ,[egg4] = @egg4
                                    ,[eggplant4] = @eggplant4
                                    ,[thina3] = @thina3
                                    ,[gargirim3] = @gargirim3
                                    ,[egg3] = @egg3
                                    ,[eggplant3] = @eggplant3
                                    ,[thina2] = @thina2
                                    ,[gargirim2] = @gargirim2
                                    ,[egg2] = @egg2
                                    ,[eggplant2] = @eggplant2
                                    ,[thina1] = @thina1
                                    ,[gargirim1] = @gargirim1
                                    ,[egg1] = @egg1
                                    ,[eggplant1] = @eggplant1
                                    ,[sum10] = @sum10
                                    ,[sum9] = @sum9
                                    ,[sum8] = @sum8
                                    ,[sum7] = @sum7
                                    ,[sum6] = @sum6
                                    ,[sum5] = @sum5
                                    ,[sum4] = @sum4
                                    ,[sum3] = @sum3
                                    ,[sum2] = @sum2
                                    ,[sum1] = @sum1
                                    ,[OrderCount] = @OrderCount
                                    ,[OrderSum] = @OrderSum
                                  WHERE id = @id";


        #endregion
        #region log
        public string Getlog = @"   
									select top 100 * 
                                    from [log]
                                    order by [datetime] desc
                                ";

        public string Newlog = @"
                                    INSERT INTO[dbo].[log]
                                    (    
                                    [UserID]
                                    ,[UserName]
                                    ,[datetime]
                                    ,[category]
                                    ,[action]
                                    )
                                VALUES
                                    (
                                    @UserID
                                    ,@UserName
                                    ,GETDATE()
                                    ,@category
                                    ,@action
                                    ) ";

        public string Updatelog = @"
                                    UPDATE [dbo].[log]
                                    [UserID] = @UserID
                                    ,[UserName] = @UserName
                                    ,[datetime] = @datetime
                                    ,[category] = @category
                                    ,[action] = @action

                                    WHERE id = @id
                                    ";


        #endregion


        #region users

        public string GetUsers = @"select users.*,lutRroles.[desc] fkRoleDesc 
                                    from users
                                    inner join lutRroles on (users.fkRole = lutRroles.id)
                                    ";

        public string GetUsersForLogin = @"select id, UserName, password, IsActive from users";

        public string NewUser = @"
                                    INSERT INTO[dbo].[users]
                                    (    [name]
                                        ,[password]
                                        ,[fkRole]
                                        ,[IsActive]
                                        ,[email]
                                    )
                                VALUES
                                        (@name
                                        ,@password
                                        ,@fkRole
                                        ,@IsActive
                                        ,@email
                                        ) ";

        public string UpdateUser = @"UPDATE [dbo].[users]
                                        SET [name] = @name
                                        ,[password] =@password
                                        ,[fkRole] =@fkRole
                                        ,[IsActive] =@IsActive
                                        ,[email] =@email
                                        WHERE id = @id";
        #endregion

    }
}