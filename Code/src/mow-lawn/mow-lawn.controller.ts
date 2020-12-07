import { Body, Controller, Get, Param, Query } from '@nestjs/common';
import { ApiOperation, ApiParam } from '@nestjs/swagger';
import { json } from 'express';
import { ApiresponseModule } from 'src/apiresponse/apiresponse.module';

@Controller('api')
export class MowLawnController {
    // @Get()
    // test(): string {
    //     return "This is just a testing API";
    // }

    //This api will calculate price for entered square meter
    @Get('calculatePrice/:sqMeter')
    @ApiParam({ name: "sqMeter", type: "string" })
    CalculatePrice(@Param() req): ApiresponseModule {
        var result = new ApiresponseModule();
        try {
            if (req != {} && !isNaN(req.sqMeter)) {
                if (req.sqMeter <= 15) {
                    result.Data = {
                        TotalSquareMeter: req.sqMeter,
                        PricePerSqMeter: 1,
                        Discount: "0%",
                        TotalAmount: req.sqMeter,
                        DiscountAmount: 0,
                        NetAmount: req.sqMeter
                    };
                    result.Message = "";
                }
                else if (req.sqMeter > 15 && req.sqMeter <= 25) {
                    var disAmnt = (req.sqMeter * 10) / 100;
                    var netAmnt = req.sqMeter - disAmnt;
                    result.Data = {
                        TotalSquareMeter: req.sqMeter,
                        PricePerSqMeter: 1,
                        Discount: "10%",
                        TotalAmount: req.sqMeter,
                        DiscountAmount: disAmnt.toFixed(2),
                        NetAmount: netAmnt.toFixed(2)
                    };
                    result.Message = "";
                }
                else {
                    var disAmnt = (req.sqMeter * 15) / 100;
                    var netAmnt = req.sqMeter - disAmnt;
                    result.Data = {
                        TotalSquareMeter: req.sqMeter,
                        PricePerSqMeter: 1,
                        Discount: "15%",
                        TotalAmount: req.sqMeter,
                        DiscountAmount: disAmnt.toFixed(2),
                        NetAmount: netAmnt.toFixed(2)
                    };
                    result.Message = "";
                }
            }
            else {
                result.Message = "Please enter square meter";
                result.Data = null;
            }
            result.Success = true;
        } catch (error) {
            result.Message = "Error : " + error;
            result.Data = null;
            result.Success = false;
        }
        return result;
    }
}
